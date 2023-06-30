using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concretes;

public class ProductManager : IProductService
{
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public void AddProduct(Product product)
    {
        _productDal.Add(product);
    }

    public List<Product> GetAll()
    {
        return _productDal.GetList();
    }
    public Product getById(int productId)
    {
        return _productDal.Get(p => p.Id == productId);
    }

    public void Remove(int id)
    {
        var product = _productDal.Get(p => p.Id == id);
        _productDal.Delete(product);
    }
}
