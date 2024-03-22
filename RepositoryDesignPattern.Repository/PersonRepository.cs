using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.Repository
{
    public class PersonRepository<TEntity> : Directory<TEntity> where TEntity : class
    {
        private QAContext _context;
        private DbSet<TEntity> _dbSet;
        public PersonRepository(QAContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get() => _dbSet.ToList();

        public TEntity GetPersonId(int id) => _dbSet.Find(id);
        public void DeletePersonById(int id)
        {
            var dataToDelete = _dbSet.Find(id);
            _dbSet.Remove(dataToDelete);
        }

        public void Add(TEntity data) => _dbSet.Add(data);

        public void Save() => _context.SaveChanges();

        public void Update(TEntity data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }
    }
}
