using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace TaskManager_Practice.Services.Common
{
    /// <summary>
    /// Ультимейт класс для хранения путей
    /// </summary>
    public static class Paths
    {
        [NotNull] public readonly static string BASE_DIR = Directory.GetCurrentDirectory();
        [NotNull] public readonly static string LOGS_FOLDER = $"{BASE_DIR}/Logs";

        /// <summary>
        /// Создание папок
        /// </summary>
        public static void CreateFoldersIfNotExist()
        {
            if (!Directory.Exists(LOGS_FOLDER))
                Directory.CreateDirectory(LOGS_FOLDER);
        }
    }
}