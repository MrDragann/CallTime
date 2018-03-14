namespace CallTime.Core.Enums
{
    /// <summary>
    /// Список статусов ответа
    /// </summary>
    public enum EnumResponseStatus
    {
        /// <summary>
        /// Успешно
        /// </summary>
        Success = 0,
        /// <summary>
        /// Ошибка валидации
        /// </summary>
        ValidationError = 1,
        /// <summary>
        /// Ошибка
        /// </summary>
        Error = 2,
        /// <summary>
        /// Исключение
        /// </summary>
        Exception = 3
    }
}
