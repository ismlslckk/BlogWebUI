﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebUI.AppClasses;
using BlogWebUI.Dao;
using BlogWebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        public RequestResponse Add([FromBody]Category category)
        {
            if (!ModelState.IsValid)
            {
                return Utility.ErrorResponse(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());
            }
            try
            {
                _categoryDao.Add(category);
                return Utility.OkResponse("Kategori başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                return Utility.ErrorResponse(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public RequestResponse Delete(string id)
        {
            try
            {
                _categoryDao.Delete(id);
                return Utility.OkResponse("Kategori başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return Utility.ErrorResponse(ex.Message);
            }
        }

        [HttpGet]
        public RequestResponse getCategoryById(string id)
        {
            try
            {
                Category cat = _categoryDao.GetById(id);
                if (cat == null)
                    return Utility.ErrorResponse("Kategori bulunamadı.");
                else
                {
                    Utility.SetData(cat);
                    return Utility.OkResponse("");
                }

            }
            catch (Exception ex)
            {
                return Utility.ErrorResponse(ex.Message);
            }
        }

        [HttpPut("update")]
        public RequestResponse update([FromBody]Category category)
        {
            if (!ModelState.IsValid)
            {
                return Utility.ErrorResponse(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());
            }
            try
            {
                _categoryDao.Update(category);
                return Utility.OkResponse("Kategori başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return Utility.ErrorResponse(ex.Message);
            }
        }
    }
}