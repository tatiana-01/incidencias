using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;

    public interface IHardware
    {
        Task<Hardware> ? GetByIdAsync(int id);
        Task<IEnumerable<Hardware>> ? GetAllAsync();
        IEnumerable<Hardware> Find (Expression<Func<Hardware,bool>> expression);
        void Add(Hardware entity);
        void AddRange(IEnumerable<Hardware> entities);
        void Remove(Hardware entity);
        void RemoveRange(IEnumerable<Hardware> entities);
        void Update(Hardware entity);
    }
