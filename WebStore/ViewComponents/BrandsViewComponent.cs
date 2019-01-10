using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew.Models.Product;
using WebStore.Interfaces;

namespace WebStore.ViewComponents
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductData _productData;
        public BrandsViewComponent(IProductData productData)
        {
            _productData = productData;
        }
        public async Task<IViewComponentResult> InvokeAsync(string brandId)
        {
            int.TryParse(brandId, out var brandIdResult);
            var brands = GetBrands();
            return View(new BrandCompleteViewModel()
            {
                Brands = brands,
                CurrentBrandId = brandIdResult
            });
        }
        private IEnumerable<BrandViewModel> GetBrands()
        {
            var dbBrands = _productData.GetBrands();
            return dbBrands.Select(b => new BrandViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Order = b.Order,
                ProductsCount = 0
            }).OrderBy(b => b.Order).ToList();
        }
    }

}
