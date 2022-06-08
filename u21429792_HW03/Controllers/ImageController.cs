using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using u21429792_HW03.Models;

namespace u21429792_HW03.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Image()
        {
            string[] filepaths = Directory.GetFiles(Server.MapPath("~/images/"));
            List<FileModel> images = new List<FileModel>();
            foreach (string filepath in filepaths)
            {
                images.Add(item: new FileModel { FileName = Path.GetFileName(filepath) });
            }
            return View(images);
        }

        public FileResult DownloadImage(string filename)
        {
            string path = Server.MapPath("~/images/") + filename;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", filename);
        }

        public ActionResult DeleteImage(string filename)
        {
            string path = Server.MapPath("~/images/") + filename;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return RedirectToAction("Image");
        }

        public ActionResult AboutMe()
        {

            return View();
        }

        public ActionResult Files()
        {
            return View();
        }

        public ActionResult Video()
        {
            return View();
        }
    }
}