using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartnerGroupAPI.DAL
{
    interface IData<TEntity, TKey> where TEntity : class
    {        
        List<TEntity> GetAll();
        TEntity GetByID(TKey key);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey key);

    }
}
