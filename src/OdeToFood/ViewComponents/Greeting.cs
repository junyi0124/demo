using OdeToFood.Services;
using Microsoft.AspNet.Mvc;

namespace OdeToFood.ViewComponents
{
    public class Greeting : ViewComponent
    {
        private IGreeter _greeter;

        public Greeting(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var model = _greeter.Greeting("{0}");
            return View("Default", model);
        }
    }
}
