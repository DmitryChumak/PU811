using Shop.API.Domain.Models;
using Shop.API.Domain.Services.Communication;

namespace Shop.API.Controllers
{
    public class SaveCategoryResponse : BaseResponse
    {
        public Category Category {get;set;}
        public SaveCategoryResponse(bool success, string message, Category category):base(success, message)
        {
            Category = category;
        }

        public SaveCategoryResponse(Category category): this(true, string.Empty, category){}
        public SaveCategoryResponse(string message): this(false, message, null) {}
    }
}