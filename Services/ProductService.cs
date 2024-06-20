using Application.Interfaces;
using Domain.Models;

namespace Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _uof;
        public ProductService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public List<Product> getAllProducts()
        {
            try
            {
                var products = _uof.Products.GetAll().ToList();
                if (products != null)
                {
                    return products;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Product getProductById(int id)
        {
            try
            {
                var product = _uof.Products.GetByid(id);
                if (product == null)
                {
                    return null;
                }
                return product;
            }
            catch
            {
                return null;
            }
        }

        public Product addProduct(Product product)
        {
            try
            {
                var r = _uof.Products.Add(product);
                _uof.Complete();
                return product;
            }
            catch
            {
                return null;
            }
        }
        public bool removeProduct(int id)
        {
            try
            {
                var products = _uof.Products.GetByid(id);
                _uof.Products.Delete(products);
                _uof.Complete();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Product updateProduct(Product product)
        {
            try
            {
                var result = _uof.Products.Update(product);
                _uof.Complete();
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
