using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebUI.Dao;
using BlogWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryDao _categoryDao;

        public CategoryController(ICategoryDao categoryDao)
        {
            _categoryDao = categoryDao;
        } 

        [HttpGet("all")]
        public IActionResult All()
        {
            return Ok(_categoryDao.All());
        }


        [HttpPost("add")]
        public IActionResult Add([FromForm]Category category)
        {
            _categoryDao.Add(category);
            return Ok(new { Message = "Kategori başarıyla eklendi."});
        }
    }
}