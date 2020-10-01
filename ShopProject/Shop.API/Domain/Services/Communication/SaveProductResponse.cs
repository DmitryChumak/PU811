using Shop.API.Domain.Models;

namespace Shop.API.Domain.Services.Communication
{
    public class SaveProductResponse : BaseResponse
    {
        public Product Product {get;set;}

        public SaveProductResponse(bool success, string message, Product product):base(success, message)
        {
            Product = product;
        }

        public SaveProductResponse(Product product): this(true, string.Empty, product){}
        public SaveProductResponse(string message): this(false, message, null) {}
    }
}