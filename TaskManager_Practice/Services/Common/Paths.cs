using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace TaskManager_Practice.Services.Common
{
    /// <summary>
    /// Ультимейт класс для хранения путей
    /// </summary>
    public static class Paths
    {
        [NotNull] public static readonly string BASE_DIR = Directory.GetCurrentDirectory();
        [NotNull] public static readonly string LOGS_FOLDER = $"{BASE_DIR}/Logs";
        [NotNull] public static readonly string DB_PATH = BASE_DIR + "/myDb.db";

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