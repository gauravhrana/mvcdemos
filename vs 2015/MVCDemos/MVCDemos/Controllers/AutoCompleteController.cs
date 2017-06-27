using MVCDemos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCDemos.Controllers
{
    public class AutoCompleteController : Controller
    {
        public ActionResult TextBox()
        {
            return View();
        }

        [HttpPost]
        public JsonResult TextBox(string keyword)
        {
            //This can be replaced with database call.  
            List<AutoCompleteGames> objGameList = new List<AutoCompleteGames>() {
                new AutoCompleteGames {
                    Id = 1, Name = "Cricket"
                },
                new AutoCompleteGames {
                    Id = 2, Name = "Football"
                },
                new AutoCompleteGames {
                    Id = 3, Name = "Chess"
                },
                new AutoCompleteGames {
                    Id = 4, Name = "Valley Ball"
                },
                new AutoCompleteGames {
                    Id = 5, Name = "Kabbadi"
                },
                new AutoCompleteGames{
                    Id = 6, Name = "Hockey"
                }
            };
            var result = (from a in objGameList
                          where a.Name.ToLower().StartsWith(keyword.ToLower())
                          select new
                          {
                              a.Name
                          });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}