using System;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Models;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers;

public class PostsController : Controller
{
    private IPostRepository _postRepository;
    private ITagRepository _tagRepository;
    public PostsController(IPostRepository postRepository, ITagRepository tagRepository)
    {
        _postRepository = postRepository;
        _tagRepository = tagRepository;
    }



    public IActionResult Index()
    {
        var posts = _postRepository.Posts.Include(p => p.PostTags).ToList();
        var tags = _tagRepository.Tags.ToList();
        PostViewModel postViewModel = new PostViewModel
        {
            Posts = posts,
            Tags = tags
        };


        return View(postViewModel);
    }
    public IActionResult Details()
    {
        return View();
    }
}
