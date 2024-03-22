using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.Repository
{
    public interface Directory<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity GetPersonId(int id);
        void Add(TEntity data);
        void DeletePersonById(int id);
        void Update(TEntity data);

        void Save();
    }
}
