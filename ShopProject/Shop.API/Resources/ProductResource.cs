namespace Shop.API.Resources
{
    public class ProductResource
    {
        public int ProductId {get;set;}
        public string ProductName {get;set;}
        public int ProductCount {get;set;}
        public CategoryResource Category { get; set; }
    }
}