using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DailyMed.Blazor.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(string code);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}