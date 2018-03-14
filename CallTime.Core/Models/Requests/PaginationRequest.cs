using System.Linq;

namespace CallTime.Core.Models.Requests
{
    /// <summary>
    /// Запрос для постранички
    /// </summary>
    public class PaginationRequest
    {
        /// <summary>
        /// Пропустить записей
        /// </summary>
        public int? Skip { get; set; }
        /// <summary>
        /// Получить записей
        /// </summary>
        public int? Take { get; set; }

        public IQueryable<T> Load<T>(IQueryable<T> query)
        {
            if (Skip.HasValue)
                query = query.Skip(Skip.Value);
            if (Take.HasValue)
                query = query.Take(Take.Value);
            return query;
        }
    }

    public class PaginationRequest<T> : PaginationRequest
    {
        /// <summary>
        /// Фильтр
        /// </summary>
        public T Filter { get; set; }
    }
}
