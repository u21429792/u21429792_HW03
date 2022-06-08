using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using u21429792_HW03.Models;

namespace u21429792_HW03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the media page.";


            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, string uploadType) //INSIDE HOME
        {
            // Verify that the user selected a file
            // Not null and has a length

            if (files != null && files.ContentLength > 0 && uploadType == "Document")
            {
                // extract only the filename

                var fileName = Path.GetFileName(files.FileName);

                // store the file inside ~/App_Data/uploads folder

                var path = Path.Combine(Server.MapPath("~/files/"), fileName);

                // The chosen default path for saving

                files.SaveAs(path);
            }
            else if (files != null && files.ContentLength > 0 && uploadType == "Image")
            {
                // extract only the filename

                var fileName = Path.GetFileName(files.FileName);

                // store the file inside ~/App_Data/uploads folder

                var path = Path.Combine(Server.MapPath("~/images/"), fileName);

                // The chosen default path for saving

                files.SaveAs(path);
            }
            // redirect back to the index action to show the form once again

            else if(files != null && files.ContentLength > 0 && uploadType == "Video")
            {
                // extract only the filename

                var fileName = Path.GetFileName(files.FileName);

                // store the file inside ~/App_Data/uploads folder

                var path = Path.Combine(Server.MapPath("~/videos/"), fileName);

                // The chosen default path for saving

                files.SaveAs(path);
            }
            return RedirectToAction("Index");
        }

    public ActionResult AboutMe()
        {

            return View();
        }

        public ActionResult Files()
        {
            return View();

        }

        public ActionResult Image()
        {
            return View();
        }

        public ActionResult Video()
        {
            return View();
        }
    } 
}