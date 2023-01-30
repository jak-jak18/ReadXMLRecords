using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXMLRecords
{
    internal class
    {
         public class DefaultController : Controller
    {
        /// <summary>
        /// GET: /Default/
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Robots()
        {
            Response.ContentType = "text/plain";
            return View();
        }
    }
}
}
