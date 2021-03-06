﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExploreCalifornia.Models;
using System.Collections;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ExploreCalifornia.Controllers {

    [Route("Blog")]
    public class BlogController : Controller {

        private readonly BlogDataContext _db;

        public BlogController(BlogDataContext db) {
            _db = db;
        }

        [Route("")]
        public IActionResult Index()
        {
            IList<Post> posts = _db.Posts.OrderByDescending(x=>x.Posted).Take(5).ToArray();
            //IList<Post> posts = new List<Post>();
            //posts.Add(new Post
            //{
            //    Title = "My blog post",
            //    Posted = DateTime.Now,
            //    Author = "Niall McCarthy",
            //    Body = "This is a blog post",
            //});
            //posts.Add(new Post
            //{
            //    Title = "My second blog post",
            //    Posted = DateTime.Now,
            //    Author = "Niall McCarthy",
            //    Body = "This is another blog post",
            //});
            return View(posts);
        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            Post post = _db.Posts.FirstOrDefault(x => x.Key == key);
            //Post post = new Post
            //{
            //    Title = "My blog post",
            //    Posted = DateTime.Now,
            //    Author = "Niall McCarthy",
            //    Body = "This is the body",
            //};

            return View(post);
        }

        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("create")]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View();

            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;

            _db.Posts.Add(post);
            _db.SaveChanges();

            return RedirectToAction("Post", "Blog", new
            {
                year = post.Posted.Year,
                month = post.Posted.Month,
                key = post.Key
            });
        }

    }
}
