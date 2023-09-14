
using DAL;
using News.Filter;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class NewsController : Controller
    {
        NewsRepository newsRepository;
        ImageRepository imageRepository;
        CategoryRepository categoryRepository;
        public NewsController(NewsRepository newsRepo,ImageRepository imageRepo,CategoryRepository categoryRepo)
        {
            newsRepository = newsRepo;
            imageRepository = imageRepo;
            categoryRepository = categoryRepo;
        }
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
    }
}