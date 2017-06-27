using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;

namespace MVCDemos.Controllers
{
    public class MVCSamplesController : Controller
    {
        // GET: MVCSamples
        public ActionResult Index()
        {
            return View();
        }

        private List<SelectListItem> GetCountries()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "India", Value = "1" });
            li.Add(new SelectListItem { Text = "Srilanka", Value = "2" });
            li.Add(new SelectListItem { Text = "China", Value = "3" });
            li.Add(new SelectListItem { Text = "Austrila", Value = "4" });
            li.Add(new SelectListItem { Text = "USA", Value = "5" });
            li.Add(new SelectListItem { Text = "UK", Value = "6" });

            return li;
        }
        public ActionResult CascadingDropDownDemo()
        {
            var li = GetCountries();

            ViewData["country"] = li;
            return View();
        }

        [HttpPost]
        public ActionResult CascadingDropDownDemo(FormCollection formData)
        {
            string country = Convert.ToString(formData["Country"]);
            string state = Convert.ToString(formData["State"]);
            string city = Convert.ToString(formData["City"]);


            ViewBag.CountryLabel = country;
            ViewBag.StateLabel = state;
            ViewBag.CityLabel = city;

            var li = GetCountries();

            ViewData["country"] = li;
            return View();
        }

        public JsonResult GetStates(string id)
        {
            List<SelectListItem> states = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    states.Add(new SelectListItem { Text = "Select", Value = "0" });
                    states.Add(new SelectListItem { Text = "ANDAMAN & NIKOBAR ISLANDS", Value = "1" });
                    states.Add(new SelectListItem { Text = "ANDHRA PRADESH", Value = "2" });
                    states.Add(new SelectListItem { Text = "ARUNACHAL PRADESH", Value = "3" });
                    states.Add(new SelectListItem { Text = "ASSAM", Value = "4" });
                    states.Add(new SelectListItem { Text = "BIHAR", Value = "5" });
                    states.Add(new SelectListItem { Text = "CHANDIGARH", Value = "6" });
                    states.Add(new SelectListItem { Text = "CHHATTISGARH", Value = "7" });
                    states.Add(new SelectListItem { Text = "DADRA & NAGAR HAVELI", Value = "8" });
                    states.Add(new SelectListItem { Text = "DAMAN & DIU", Value = "9" });
                    states.Add(new SelectListItem { Text = "GOA", Value = "10" });
                    states.Add(new SelectListItem { Text = "GUJARAT", Value = "11" });
                    states.Add(new SelectListItem { Text = "HARYANA", Value = "12" });
                    states.Add(new SelectListItem { Text = "HIMACHAL PRADESH", Value = "13" });
                    states.Add(new SelectListItem { Text = "JAMMU & KASHMIR", Value = "14" });
                    states.Add(new SelectListItem { Text = "JHARKHAND", Value = "15" });
                    states.Add(new SelectListItem { Text = "KARNATAKA", Value = "16" });
                    states.Add(new SelectListItem { Text = "KERALA", Value = "17" });
                    states.Add(new SelectListItem { Text = "LAKSHADWEEP", Value = "18" });
                    states.Add(new SelectListItem { Text = "MADHYA PRADESH", Value = "19" });
                    states.Add(new SelectListItem { Text = "MAHARASHTRA", Value = "20" });
                    states.Add(new SelectListItem { Text = "MANIPUR", Value = "21" });
                    states.Add(new SelectListItem { Text = "MEGHALAYA", Value = "22" });
                    states.Add(new SelectListItem { Text = "MIZORAM", Value = "23" });
                    states.Add(new SelectListItem { Text = "NAGALAND", Value = "24" });
                    states.Add(new SelectListItem { Text = "NCT OF DELHI", Value = "25" });
                    states.Add(new SelectListItem { Text = "ORISSA", Value = "26" });
                    states.Add(new SelectListItem { Text = "PUDUCHERRY", Value = "27" });
                    states.Add(new SelectListItem { Text = "PUNJAB", Value = "28" });
                    states.Add(new SelectListItem { Text = "RAJASTHAN", Value = "29" });
                    states.Add(new SelectListItem { Text = "SIKKIM", Value = "30" });
                    states.Add(new SelectListItem { Text = "TAMIL NADU", Value = "31" });
                    states.Add(new SelectListItem { Text = "TRIPURA", Value = "32" });
                    states.Add(new SelectListItem { Text = "UTTAR PRADESH", Value = "33" });
                    states.Add(new SelectListItem { Text = "UTTARAKHAND", Value = "34" });
                    states.Add(new SelectListItem { Text = "WEST BENGAL", Value = "35" });
                    break;
                case "UK":
                    break;
                case "India":
                    break;
            }
            return Json(new SelectList(states, "Value", "Text"));
        }

        public JsonResult GetCity(string id)
        {
            List<SelectListItem> City = new List<SelectListItem>();

            //switch (id)
            //{
            //    case "20":
            //    default:

            //        break;
            //}
            City.Add(new SelectListItem { Text = "Select", Value = "0" });
            City.Add(new SelectListItem { Text = "MUMBAI", Value = "1" });
            City.Add(new SelectListItem { Text = "PUNE", Value = "2" });
            City.Add(new SelectListItem { Text = "KOLHAPUR", Value = "3" });
            City.Add(new SelectListItem { Text = "RATNAGIRI", Value = "4" });
            City.Add(new SelectListItem { Text = "NAGPUR", Value = "5" });
            City.Add(new SelectListItem { Text = "JALGAON", Value = "6" });

            return Json(new SelectList(City, "Value", "Text"));
        }

        public ActionResult CKEditorSample()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CKEditorSample(FormCollection formData)
        {

            var email = Convert.ToString(formData["Email"]);
            var htmlContent = Convert.ToString(formData["Note"]);

            if (!string.IsNullOrEmpty(email))
            {
                var emailBody = htmlContent;

                var toEmail = ConfigurationManager.AppSettings["toEmail"];
                var fromEmail = ConfigurationManager.AppSettings["fromEmail"];
                var emailPassword = ConfigurationManager.AppSettings["emailPassword"];
                var emailUserName = ConfigurationManager.AppSettings["emailUserName"];

                var mail = new MailMessage();

                mail.To.Add(toEmail);
                mail.To.Add("contact@ghrana.com");

                mail.From = new MailAddress(fromEmail);
                mail.Subject = "Html Content sent from mvcdemos by gaurav rana";
                mail.Body = emailBody;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient();
                smtp.Send(mail);

                ViewBag.successMessage = "Thank you, <br/> HTML Content is sent to " + email;
            }

            return View();
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetPDFReport()
        {
            //string fileName = string.Concat("Contacts.pdf");
            //string filePath = HttpContext.Current.Server.MapPath("~/Report/" + fileName);

            //ContactController contact = new ContactController();
            //List<Contact> contacList = contact.Get().ToList();

            //await SampleEF6.Report.ReportGenerator.GeneratePDF(contacList, filePath);

            HttpResponseMessage result = null;
            //result = Request.CreateResponse(HttpStatusCode.OK);
            //result.Content = new StreamContent(new FileStream(filePath, FileMode.Open));
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            //result.Content.Headers.ContentDisposition.FileName = fileName;

            return result;
        }

    }
}