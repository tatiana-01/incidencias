using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;

    public interface IPuesto
    {
        Task<Puesto> ? GetByIAsync(int id);
        Task<IEnumerable<Puesto>> ? GetAllAsync();
        IEnumerable<Puesto> Find(Expression<Func<Puesto,bool>> expression);
        void Add(Puesto entity);
        void AddRange(IEnumerable<Puesto> entities);
        void Remove(Puesto entity);
        void RemoveRange(IEnumerable<Puesto> entities);
        void Update(Puesto entity);
    }
