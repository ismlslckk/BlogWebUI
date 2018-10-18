using BlogWebUI.Dao;
using BlogWebUI.Data;
using BlogWebUI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlogWebUI.DaoImpl
{
    public class BlogDaoImpl : IBlogDao
    {
        private readonly DataContext _dataContext;
        public IMongoCollection<Blog> BlogCollection;

        public BlogDaoImpl(DataContext dataContext)
        {
            _dataContext = dataContext;
            BlogCollection = dataContext.GetCollection<Blog>();
        }


        public void Add(Blog b)
        {
            BlogCollection.InsertOne(b);
        }

        public IEnumerable<Blog> All()
        {
            return BlogCollection.AsQueryable().ToList();
        }

        public void Delete(string id)
        {
            BlogCollection.DeleteOne(x => x.Id == id);
        }

        public Blog GetById(string id)
        {
            return BlogCollection.AsQueryable().FirstOrDefault(x => x.Id == id);
        }

        public void Update(Blog b)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>();
            foreach (PropertyInfo propertyInfo in b.GetType().GetProperties())
            {
                filter.Add(propertyInfo.Name, propertyInfo.GetValue(b));
            }

            BlogCollection.ReplaceOne(x => x.Id == b.Id, b);
        }
    }
}
