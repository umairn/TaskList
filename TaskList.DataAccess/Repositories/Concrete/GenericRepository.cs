using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {/// <summary>
     /// 
     /// </summary>
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// 
        /// </summary>
        private DbContext _context;
        /// <summary>
        /// 
        /// </summary>
        private DbSet<TEntity> entities;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(DbContext context)
        {
            _context = context;
            entities = _context.Set<TEntity>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> Add(TEntity entity)
        {
            CheckContext();
            await Entities.AddAsync(entity);
            Save();
            return entity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            CheckContext();

            Save();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            CheckContext();

            return Entities;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            CheckContext();
            _context.Update(entity);
            Save();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {

            _context.SaveChanges();

        }
        /// <summary>
        /// 
        /// </summary>
        private void CheckContext()
        {
            _context = _unitOfWork.Get<DbContext>();

        }
        /// <summary>
        /// 
        /// </summary>
        private DbSet<TEntity> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = _context.Set<TEntity>();
                }
                return entities;
            }
        }
    }
}
