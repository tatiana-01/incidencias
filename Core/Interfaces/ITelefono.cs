using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;

    public interface ITelefono
    {
        Task<Telefono> ? GetByIdAsync(int id);
        Task<IEnumerable<Telefono>> ? GetAllAsync();
        IEnumerable<Telefono> Find(Expression<Func<Telefono,bool>> expression);
        void Add(Telefono entity);
        void AddRange(IEnumerable<Telefono> entities);
        void Remove(Telefono entity);
        void RemoveRange(IEnumerable<Telefono> entities);
        void Update(Telefono entity);
    }
