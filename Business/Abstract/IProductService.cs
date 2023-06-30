using Entities.Concrete;

namespace Business.Abstract;

public interface IProductService
{
    List<Product> GetAll();
    Product getById(int productId);
    void Remove(int id);
    void AddProduct(Product product);
}
