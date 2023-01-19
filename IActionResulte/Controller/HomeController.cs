using Microsoft.AspNetCore.Mvc;

namespace IActionResulte.Controller
{
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
            // Book id shuld be applid
            if(!Request.Query.ContainsKey("bookid"))
        }
    }
}
