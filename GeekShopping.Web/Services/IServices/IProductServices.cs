using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductModel>> FindAllProducts();
        Task<ProductModel> FindProductById(int id);
        Task<ProductModel> Create(ProductModel product);
        Task<ProductModel> Update(ProductModel product);
        Task<bool> Delete(int id);
    }
}
