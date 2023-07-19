using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;

    public interface ITipoSoftware
    {
        Task<TipoSoftware> ? GetByIdAsync(int id);
        Task<IEnumerable<TipoSoftware>> ? GetAllAsync();
        IEnumerable<TipoSoftware> Find(Expression<Func<TipoSoftware, bool>> expression);
        void Add(TipoSoftware entity);
        void AddRange(IEnumerable<TipoSoftware> entities);
        void Remove(TipoSoftware entity);
        void RemoveRange(IEnumerable<TipoSoftware> entities);
        void Update(TipoSoftware entity);
    }
