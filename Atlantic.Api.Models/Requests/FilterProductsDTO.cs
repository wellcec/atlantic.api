namespace Atlantic.Api.Models.Requests
{
    public class FilterProductsDTO
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public bool asc { get; set; }
        public string term { get; set; }
        public string categoryId { get; set; }
        public string nameSubcategory { get; set; }
        public string[] tags { get; set; }
        public double? minValue { get; set; }
        public double? maxValue { get; set; }

    }
}
