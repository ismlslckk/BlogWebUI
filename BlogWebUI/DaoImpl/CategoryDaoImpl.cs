using BlogWebUI.Dao;
using BlogWebUI.Data;
using BlogWebUI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.DaoImpl
{
    public class CategoryDaoImpl : ICategoryDao
    {
        private readonly DataContext _dataContext;
        public IMongoCollection<Category> CategoryCollection;

        public CategoryDaoImpl(DataContext dataContext)
        {
            _dataContext = dataContext;
            CategoryCollection = dataContext.GetCollection<Category>();
        }

        public void Add(Category p)
        {
            CategoryCollection.InsertOne(p);
        }

        public IEnumerable<Category> All()
        {
            return CategoryCollection.AsQueryable().ToList();
        }

        public void Delete(string id)
        {
            CategoryCollection.DeleteOne(x => x.Id == id);
        }

        public Category GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            throw new NotImplementedException();
        }
    }
}
