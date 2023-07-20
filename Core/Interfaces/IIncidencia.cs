using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;

    public interface IIncidencia
    {
        Task<Incidencia> ? GetByIdAsync(int id);
        Task<IEnumerable<Incidencia>> ? GetAllAsync();
        IEnumerable<Incidencia> Find(Expression<Func<Incidencia,bool>> expression);
        void Add (Incidencia entity);
        void AddRange(IEnumerable<Incidencia> entities);
        void Remove(Incidencia entity);
        void RemoveRange(IEnumerable<Incidencia> entities);
        void Update(Incidencia entity);
    }
