using MVCDemos.Models;
using MVCDemos.Repositories;
using Newtonsoft.Json;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCDemos.Controllers
{
    public class DataController : Controller
    {

        #region LoadData   

        [HttpPost]
        public JsonResult LoadAngularJsDataTableData()
        {
            List<Book> BookList = new List<Book>();

            using (ISession session = NHibernateHelper.OpenSession())  // Open a session to conect to the database
            {
                BookList = new BookRepository().GetAll().ToList(); //  Querying to get all the books
            }
            return Json(BookList, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region EditData  

        [HttpPost]
        public string EditAngularJsDataTableData(Book Param)
        {
            using (ISession session = NHibernateHelper.OpenSession())  // Open a session to conect to the database
            {
                new BookRepository().Update(Param); //  Querying to get all the books
            }

            return "Success";
        }

        #endregion

        #region EditData  

        [HttpPost]
        public string DeleteAngularJsDataTableData(Book Param)
        {
            using (ISession session = NHibernateHelper.OpenSession())  // Open a session to conect to the database
            {
                new BookRepository().Remove(Param); //  Querying to get all the books
            }

            return "Success";
        }

        #endregion
    }
}
