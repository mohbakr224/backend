using Assignment_11.Models;
using Assignment_11.Pagination;
using Assignment_11.Repositry;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment_11.Serivces
{
    public class ProductServices
    {
        private readonly ProductsRepo _productsRepo;
        public ProductServices(ProductsRepo productsRepo)
        {
            _productsRepo = productsRepo;
        }

        public PageResults<Products> filteringProducts(PageFilter pageFilter)
        {
            List<Products> products = _productsRepo.FetchProducts();
            if (!string.IsNullOrWhiteSpace(pageFilter.ProductName))
            {
                products = products
                    .Where(product => product.name.Contains(pageFilter.ProductName))
                    .ToList();
            }

            if (pageFilter.IsAvaliable.HasValue)
            {
                products = products
                    .Where(product => product.available == pageFilter.IsAvaliable.Value)
                    .ToList();
            }

            if (pageFilter.IsFavorite.HasValue)
            {
                products = products
                    .Where(product => product.isFavorite == pageFilter.IsFavorite.Value)
                    .ToList();
            }

            //sort
            var allowedSort = new Dictionary<string, Func<Products, object>>        {
                      { "name", p => p.name },
                      { "price", p => p.price },
                      { "favorite", p => p.isFavorite },
                      { "available", p => p.available }
                      };

            if (allowedSort.TryGetValue(pageFilter.sortby, out var selector))
            {
                products.OrderBy(selector);
            }

            return new PageResults<Products>
            {
                Page = pageFilter.Page,
                PageSize = pageFilter.PageSize,
                Data = products.Skip(pageFilter.Page - 1 * pageFilter.PageSize).Take(pageFilter.PageSize).ToList(),
                totalproducts = products.Count
            };



        }
    }
}
