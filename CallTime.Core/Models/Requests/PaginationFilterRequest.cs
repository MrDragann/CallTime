namespace CallTime.Core.Models.Requests
{
    public class PaginationFilterRequest : PaginationRequest
    {
        /// <summary>
        /// Поисковый запрос
        /// </summary>
        public string Term { get; set; }
        /// <summary>
        /// Целое Ид
        /// </summary>
        public int? IntId { get; set; }
    }
}
