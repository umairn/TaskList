using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.DataAccess
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {/// <summary>
     /// 
     /// </summary>
     /// <returns></returns>
        IEnumerable<TEntity> GetAll();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> Add(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
        /// <summary>
        /// 
        /// </summary>
        void Save();
    }
}
