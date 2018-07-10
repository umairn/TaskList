using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {/// <summary>
     /// 
     /// </summary>
        private DbContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            _context = null;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>() where T : class
        {
            return _context as T;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}