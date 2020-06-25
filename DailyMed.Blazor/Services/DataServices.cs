using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DailyMed.Blazor.Data;
using DailyMed.Blazor.Models;
using DailyMed.Blazor.Interfaces;

namespace DailyMed.Blazor.Services
{
    public class DataServices : IDataRepository
    {
        #region Private members
        private DailyContext _context;
        #endregion

        #region Constructor
        public DataServices(DailyContext context)
        {
            this._context = context;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// This method returns the list of data
        /// </summary>
        /// <returns></returns>
        public async Task<List<Datum>> GetAllAsync()
        {
            return await _context.Data.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// This method returns a datum based from code parameter
        /// </summary>
        /// <returns></returns>
        public async Task<Datum> GetAsync(string code)
        {
            return await _context.Data.FindAsync(code);
        }

        /// <summary>
        /// This method add a new data to the DbContext and saves it
        /// </summary>
        /// <param name="datum"></param>
        /// <returns></returns>
        public async Task AddAsync(Datum datum)
        {
            try
            {
                _context.Data.Add(datum);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method update and existing data and saves the changes
        /// </summary>
        /// <param name="datum"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Datum datum)
        {
            try
            {
                var exist = _context.Data.FirstOrDefault(d => d.Code == datum.Code);
                
                if (exist != null)
                {
                    _context.Update(datum);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method removes and existing data from the DbContext and saves it
        /// </summary>
        /// <param name="datum"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Datum datum)
        {
            try
            {
                _context.Data.Remove(datum);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
