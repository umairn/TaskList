using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList.DataAccess
{
    public interface IUnitOfWork
    {/// <summary>
     /// 
     /// </summary>
     /// <typeparam name="T"></typeparam>
     /// <returns></returns>
        T Get<T>() where T : class;
        /// <summary>
        /// 
        /// </summary>
        void Commit();
        /// <summary>
        /// 
        /// </summary>
        void Clear();
        /// <summary>
        /// 
        /// </summary>
        void Save();
    }
}
