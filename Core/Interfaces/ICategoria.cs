using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

    public interface ICategoria
    {
        Task<Categoria> ? GetByIdAsync(int id);
        Task<IEnumerable<Categoria>> ? GetAllAsync();
        IEnumerable<Categoria> Find(Expression<Func<Categoria,bool>> expression);
        void Add(Categoria entity);
        void AddRange(IEnumerable<Categoria> entities);
        void Remove(Categoria entity);
        void RemoveRange(IEnumerable<Categoria> entities);
        void Update(Categoria entity);
    }
