using System;

namespace TaskManager_Practice.Services.Common
{
    /// <summary>
    /// Сюда можно добавлять всякие методы-хелперы
    /// </summary>
    public static class Utils
    {
        public static void NotNull(object obj, string objectName)
        {
            switch (obj)
            {
                case string str when string.IsNullOrEmpty(str):
                    throw new ArgumentException(str, "string is empty");
                case null:
                    throw new ArgumentNullException(objectName);
            }
        }
    }
}