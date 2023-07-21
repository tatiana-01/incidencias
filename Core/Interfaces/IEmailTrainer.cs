using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;

    public interface IEmailTrainer
    {
        Task<EmailTrainer> ? GetByIdAsync(string idTrainer, int idEmail);
        Task<EmailTrainer> ? GetByIdTrainerAsync(string idTrainer);
        Task<IEnumerable<EmailTrainer>> ? GetAllAsync();
        IEnumerable<EmailTrainer> Find(Expression<Func<EmailTrainer,bool>> expression);
        void Add(EmailTrainer entity);
        void AddRange(IEnumerable<EmailTrainer> entities);
        void Remove (EmailTrainer entity);
        void RemoveRange(IEnumerable<EmailTrainer> entities);
        void Update(EmailTrainer entity);
    }
