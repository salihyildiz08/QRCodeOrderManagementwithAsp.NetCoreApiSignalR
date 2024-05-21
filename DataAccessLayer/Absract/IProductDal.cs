using EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Absract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();

         int ProductCount();
    }
}
