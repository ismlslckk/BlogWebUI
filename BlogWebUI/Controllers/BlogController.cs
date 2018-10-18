using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebUI.AppClasses;
using BlogWebUI.Dao;
using BlogWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private readonly IBlogDao _blogDao;

        public BlogController(IBlogDao blogDao)
        {
            _blogDao = blogDao;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            return Ok(_blogDao.All());
        }

        [HttpPost("add")]
        public RequestResponse Add([FromBody]Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return Utility.ErrorResponse(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());
            }
            try
            {
                _blogDao.Add(blog);
                return Utility.OkResponse("Blog başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                return Utility.ErrorResponse(ex.Message);
            }
        }
    }
}