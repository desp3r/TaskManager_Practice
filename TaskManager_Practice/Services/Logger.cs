using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using TaskManager_Practice.Services.Common;

namespace TaskManager_Practice.Services
{
    public static class Logger
    {
        private const int MAX_FILE_LENGTH = 200000;
        private static string _CurrentLogFileName;
        private static bool _IsActive;
        public static string CurrentLogFileName => Paths.LOGS_FOLDER + "\\" + _CurrentLogFileName;

        private static string CreateLogFileName(int partIndex)
        {
            return DateTime.Today.ToString("yy-MM-dd") + " " + partIndex + " " +
                   Process.GetCurrentProcess().ProcessName + ".log";
        }

        public static void Initialize()
        {
            if (_IsActive)
                return;

            _IsActive = true;
            var partIndex = 0;
            while (true)
            {
                _CurrentLogFileName = CreateLogFileName(partIndex);

                var logFileName = CurrentLogFileName;

                if (!File.Exists(logFileName))
                {
                    using var sw = File.CreateText(logFileName);
                    sw.Close();
                    sw.Dispose();
                    break;
                }

                var fileBytes = File.ReadAllBytes(logFileName);
                if (fileBytes.Length > MAX_FILE_LENGTH)
                {
                    partIndex++;
                    continue;
                }

                break;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Write(string message)
        {
            if (string.IsNullOrEmpty(message) || !_IsActive)
                return;
            try
            {
                var line = $"{DateTime.Now.ToString("HH:mm:ss")} {message}{Environment.NewLine}";

                File.AppendAllText(CurrentLogFileName, line);
            }
            catch (IOException)
            {
                // ignored
            }
        }

        public static void WriteCritical(string message) => Write("CRITICAL! " + message);
        public static void WriteError(string message) => Write("ERROR! " + message);
        public static void WriteWarning(string message) => Write("WARNING! " + message);
        public static void WriteInfo(string message) => Write("INFO: " + message);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void WriteWithThreadId(string message) => Write(message + " THREAD: " + Thread.CurrentThread.ManagedThreadId);
    }
}