using Microsoft.AspNetCore.Mvc;

namespace TakeAway.WebUI.ViewComponents.ProductViewComponents
{
    public class ProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
