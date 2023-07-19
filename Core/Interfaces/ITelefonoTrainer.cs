using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;

    public interface ITelefonoTrainer
    {
        Task<TelefonoTrainer> ? GetByIdAsync(int id);
        Task<IEnumerable<TelefonoTrainer>> ? GetAllAsync();
        IEnumerable<TelefonoTrainer> Find(Expression<Func<TelefonoTrainer, bool>> expression);
        void Add(TelefonoTrainer entity);
        void AddRange(IEnumerable<TelefonoTrainer> entities);
        void Remove(TelefonoTrainer entity);
        void RemoveRange(IEnumerable<TelefonoTrainer> entities);
        void Update(TelefonoTrainer entity);
    }
