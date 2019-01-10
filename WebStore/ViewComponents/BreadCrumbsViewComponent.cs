using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.ViewComponents
{
    public class BreadCrumbsViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}