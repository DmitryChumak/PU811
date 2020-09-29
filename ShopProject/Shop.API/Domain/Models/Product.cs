namespace Shop.API.Domain.Models
{
    public class Product
    {
        public int ProductId {get;set;}
        public string ProductName {get;set;}
        public int ProductCount {get;set;}
        public int CategoryId {get;set;}
        public Category Category {get;set;}
    }
}