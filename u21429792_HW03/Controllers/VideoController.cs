using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using u21429792_HW03.Models;

namespace u21429792_HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Video()
        {
            string[] filepaths = Directory.GetFiles(Server.MapPath("~/videos/"));
            List<FileModel> videos = new List<FileModel>();
            foreach (string filepath in filepaths)
            {
                videos.Add(item: new FileModel { FileName = Path.GetFileName(filepath) });
            }
            return View(videos);
        }

        public FileResult DownloadVideo(string filename)
        {
            string path = Server.MapPath("~/videos/") + filename;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", filename);
        }

        public ActionResult DeleteVideo(string filename)
        {
            string path = Server.MapPath("~/videos/") + filename;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return RedirectToAction("Video");
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
    }
}