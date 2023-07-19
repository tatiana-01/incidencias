using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;

    public interface ISoftware
    {
        Task<Software> ? GetByIdAsync(int id);
        Task<IEnumerable<Software>> ? GetAllAsync();
        IEnumerable<Software> Find(Expression<Func<Software,bool>> expression);
        void Add(Software entity);
        void AddRange(IEnumerable<Software> entities);
        void Remove(Software entity);
        void RemoveRange(IEnumerable<Software> entities);
        void Update (Software entity);
    }
