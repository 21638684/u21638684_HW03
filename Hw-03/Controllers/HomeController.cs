using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.IO;
using Hw_03.Models;


namespace Hw_03.Controllers
{
    public class HomeController : Controller
    {//get
        // Home controller
        public ActionResult HOME()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HOME(string Media, HttpPostedFileBase file)
        {

            if (Media == "documents" && file.ContentLength>0)
            {
                string path = Path.Combine(Server.MapPath("~/Media/Documents"), Path.GetFileName(file.FileName));
                file.SaveAs(path);

            }
            else if (Media == "images"&& file.ContentLength>0)
            {
                string path = Path.Combine(Server.MapPath("~/Media/Images"), Path.GetFileName(file.FileName));
                file.SaveAs(path);

            }
            else if (Media == "videos" && file.ContentLength>0)
            {
                string path = Path.Combine(Server.MapPath("~/Media/Videos"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
            }

            ViewBag.Message = "Uploaded Successfully";
            return View();
        } 
        // File controller
        public ActionResult Files()
        {
            string[] PathA= Directory.GetFiles(Server.MapPath("~/Media/Documents"));
            List<FileModel> files = new List<FileModel>();

            foreach(string FilePath in PathA)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(FilePath) });
            }
            
            return View(files);
        }

        public FileResult DownloadFiles(string name )
        {
            string pathfile = Server.MapPath("~/Media/Images/") + name;
            byte[] bytes = System.IO.File.ReadAllBytes(pathfile);
            return File(bytes, "application/octet-stream", name);
        }

        public void DeleteFiles(string name)
        {
            string PathC = Request.MapPath("~/Media/Document") + name;

            
            if (System.IO.File.Exists(PathC))
            {
                System.IO.File.Delete(PathC);
            }
            
        }

        // image controller
        public ActionResult Images()
        {
            string[] PathA = Directory.GetFiles(Server.MapPath("~/Media/Images"));
            List<FileModel> files = new List<FileModel>();

            foreach (string FilePath in PathA)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(FilePath)});
            }

            return View(files);

        }
        public FileResult DownloadImages(string name)
        {
            string pathfile = Server.MapPath("~/Media/Images/") + name;
            byte[] bytes = System.IO.File.ReadAllBytes(pathfile);
            return File(bytes, "application/octet-stream", name);

        }

        public void DeleteImages(string name)
        {
            string PathC = Request.MapPath("~/Media/Document") + name;


            if (System.IO.File.Exists(PathC))
            {
                System.IO.File.Delete(PathC);
            }

        }

        // video controller
        public ActionResult Videos()
        {
            string[] PathA = Directory.GetFiles(Server.MapPath("~/Media/Images"));
            List<FileModel> files = new List<FileModel>();

            foreach (string FilePath in PathA)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(FilePath) });
            }

            return View(files);
        }
            public FileResult DownloadVideos(string name)
        {
            string pathfile = Server.MapPath("~/Media/Videos/") + name;
            byte[] bytes = System.IO.File.ReadAllBytes(pathfile);
            return File(bytes, "application/octet-stream", name);

        }

        public void DeleteVideos(string name)
        {
            string PathC = Request.MapPath("~/Media/Videos/") + name;


            if (System.IO.File.Exists(PathC))
            {
                System.IO.File.Delete(PathC);
            }

        }
        // About controller
            public ActionResult About()
        {
            return View();
        }
        
    }
}
