namespace OatMilk.Backend.Api.Services.Pagination
{
    public class SortedPageFilter : PageFilter
    {
        /// <summary>
        /// Name of the column to sort by.
        /// </summary>
        public string SortColumnName { get; set; }
        
        /// <summary>
        /// Whether or not to sort in ascending order.
        /// </summary>
        public bool? SortAscending { get; set; }
    }
}