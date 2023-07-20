using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;

    public interface ISalon
    {
        Task<Salon> ? GetByIdAsync(int id);
        Task<IEnumerable<Salon>> ? GetAllAsync();
        IEnumerable<Salon> Find(Expression<Func<Salon,bool>> expression);
        void Add(Salon entity);
        void AddRange(IEnumerable<Salon> entities);
        void Remove(Salon entity);
        void RemoveRange(IEnumerable<Salon> entities);
        void Update(Salon entity);

    }
