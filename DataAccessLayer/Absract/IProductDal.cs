using EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Absract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();

         int ProductCount();
         int ProductCountByCategoryNameHamburger();
         int ProductCountByCategoryNameDrink();
        decimal ProductPriceAvg();
        decimal ProductPriceAvgByHamburger();

        string ProductNameByMaxPrice();
        string ProductNameByMinPrice();

    }
}
