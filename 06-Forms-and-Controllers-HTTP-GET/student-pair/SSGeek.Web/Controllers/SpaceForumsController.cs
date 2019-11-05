using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class SpaceForumsController : Controller
    {

        private IForumPostDAO forumPostDAO;
        //Inject controller
        public SpaceForumsController(IForumPostDAO forumPostDAO)
        {

            this.forumPostDAO = forumPostDAO;
        }

        public IActionResult Index()
        {
            IList<ForumPost> forum = forumPostDAO.GetAllPosts();
            
            return View(forum);
        }
        [HttpGet]
        public IActionResult NewPost()
        {
            ForumPost forum = new ForumPost();
            return View(forum);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewPost(ForumPost post)
        {
            forumPostDAO.SaveNewPost(post);

            return RedirectToAction("Index");
        }
        [HttpGet]
       public IActionResult Confirmation()
        {

            return View();
        }



    }
}