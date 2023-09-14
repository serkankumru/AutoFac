using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Repository;
using News.Models;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        NewsRepository newsRepository;
        EditorRepository editorRepository;
       
        public HomeController(NewsRepository rep,EditorRepository repository)
        {
            newsRepository = rep;
            editorRepository = repository;

        }
       
        public ActionResult Index(int? id)
        {
            if(id!=null)
                return View(newsRepository.List().Where(x=>x.CatId==id).Where(X => X.Status == true).OrderBy(x => x.CreateDate).ToList());

            return View(newsRepository.List().Where(X => X.Status == true).OrderBy(x => x.CreateDate).ToList());
        }

        public PartialViewResult NewsDetail(int id)
        {
            return PartialView(newsRepository.FindById(id));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}