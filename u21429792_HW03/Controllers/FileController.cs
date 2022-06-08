using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using u21429792_HW03.Models;

namespace u21429792_HW03.Controllers
{
    public class FileController : Controller
    {
      
        public ActionResult Files()
        {
            string[] filepaths = Directory.GetFiles(Server.MapPath("~/files/"));
            List<FileModel> files = new List<FileModel>();
            foreach (string filepath in filepaths)
            {
                files.Add(item: new FileModel { FileName = Path.GetFileName(filepath) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/files/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            string path = Server.MapPath("~/files/") + fileName;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return RedirectToAction("Files");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutMe()
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