using MVCDemos.Models;
using MVCDemos.Repositories;
using NHibernate;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace MVCDemos.Controllers
{
    public class AngularJsDemosController : Controller
    {
        // GET: AngularJsDemos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MultipleFileUpload()
        {
            return View();
        }

        [HttpPost]
        public virtual string UploadFiles(object obj)
        {

            var length = Request.ContentLength;
            var bytes = new byte[length];
            Request.InputStream.Read(bytes, 0, length);

            var fileName = Request.Headers["X-File-Name"];
            var fileSize = Request.Headers["X-File-Size"];
            var fileType = Request.Headers["X-File-Type"];

            var currentPath = Server.MapPath("..//AngularFileUploadImages");

            var saveToFileLoc = currentPath + "\\" + fileName;
            var fileStream = new FileStream(saveToFileLoc, FileMode.Create, FileAccess.ReadWrite);
            fileStream.Write(bytes, 0, length);
            fileStream.Close();

            return string.Format("{0} bytes uploaded", bytes.Length);
        }

        public ActionResult AngularJsDatatable()
        {
            return View();
        }
    }
}