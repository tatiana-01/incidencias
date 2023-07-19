using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;

    public interface ITrainer
    {
        Task<Trainer> ? GetByIdAsync(string id);
        Task<IEnumerable<Trainer>> ? GetAllAsync();
        IEnumerable<Trainer> Find(Expression<Func<Trainer,bool>> expression);
        void Add(Trainer entity);
        void AddRange(IEnumerable<Trainer> entities);
        void Remove(Trainer entity);
        void RemoveRange(IEnumerable<Trainer> entities);
        void Update(Trainer entity);

    }
