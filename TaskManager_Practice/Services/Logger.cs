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
        private static string __CurrentLogFileName;
        private static bool __IsActive;
        public static string CurrentLogFileName => Paths.LOGS_FOLDER + "\\" + __CurrentLogFileName;

        private static string CreateLogFileName(int partIndex)
        {
            return DateTime.Today.ToString("yy-MM-dd") + " " + partIndex + " " +
                   Process.GetCurrentProcess().ProcessName + ".log";
        }

        public static void Initialize()
        {
            if (__IsActive)
                return;

            __IsActive = true;
            int partIndex = 0;
            while (true)
            {
                __CurrentLogFileName = CreateLogFileName(partIndex);

                string logFileName = CurrentLogFileName;

                if (!File.Exists(logFileName))
                {
                    StreamWriter sw = File.CreateText(logFileName);
                    sw.Close();
                    sw.Dispose();
                    break;
                }

                byte[] fileBytes = File.ReadAllBytes(logFileName);
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
            if (string.IsNullOrEmpty(message) || !__IsActive)
                return;
            try
            {
                var line = $"{DateTime.Now.ToString("HH:mm:ss")} {message}{Environment.NewLine}";

                File.AppendAllText(CurrentLogFileName, line);
            }
            catch (IOException)
            {
            }
        }

        public static void WriteCritical(string message) => Write("CRITICAL! " + message);

        public static void WriteError(string message) => Write("ERROR! " + message);

        public static void WriteWarning(string message) => Write("WARNING! " + message);


        public static void WriteInfo(string message) => Write("INFO: " + message);


        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void WriteWithThreadId(string message)
        {
            Write(message + " THREAD: " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}