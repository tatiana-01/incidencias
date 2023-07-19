using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;

    public interface ItipoIncidencia
    {
        Task<TipoIncidencia> ? GetByIdAsync(int id);
        Task<IEnumerable<TipoIncidencia>> ? GetAllAsync();
        IEnumerable<TipoIncidencia> Find(Expression<Func<TipoIncidencia,bool>> expression);
        void Add(TipoIncidencia entity);
        void AddRange(IEnumerable<TipoIncidencia> entities);
        void Remove(TipoIncidencia entity);
        void RemoveRange(IEnumerable<TipoIncidencia> entities);
        void Update(TipoIncidencia entity);
    }
