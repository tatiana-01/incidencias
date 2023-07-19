using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;

    public interface ITipoHardware
    {
        Task<TipoHardware> ? GetByIdAsync(int id);
        Task<IEnumerable<TipoHardware>> ? GetAllAsync();
        IEnumerable<TipoHardware> Find(Expression<Func<TipoHardware, bool>> expression);
        void Add(TipoHardware entity);
        void AddRange(IEnumerable<TipoHardware> entities);
        void Remove(TipoHardware entity);
        void RemoveRange(IEnumerable<TipoHardware> entities);
        void Update(TipoHardware entity);
        
    }
