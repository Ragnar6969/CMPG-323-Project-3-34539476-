using DeviceManagement_WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DeviceManagement_WebApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ConnectedOfficeContext _context;
        public GenericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }

        //This adds an entity to a specific table in the database
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        //This adds multiple entities to a specific table in the database
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        //This finds an entry based on a true or false expression
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        //This method gets all entries in a specific table in the database
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        //This gets a entry based on a specific id
        public T GetById(Guid? id)
        {
            return _context.Set<T>().Find(id);
        }

        //This removes an entity from the a specific table from the database
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        //This removes multiple entities from the a specific table from the database
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        //This saves the changes to the database
        public void Save()
        {
            _context.SaveChangesAsync();
        }

        //This allows you to edit and update an already existing entry in the database
        public void update(T Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }

}
