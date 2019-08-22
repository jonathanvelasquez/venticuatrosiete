namespace venticuatrosiete.Web.Data
{

    using venticuatrosiete.Web.Data.Entities;
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }


}
