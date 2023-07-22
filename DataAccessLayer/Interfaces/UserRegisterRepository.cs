using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public class UserRegisterRepository : IRegisterRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRegisterRepository(ApplicationDbContext context)
        {
                _context=context;
        }
        public async Task<TblUserRegistration> AddTblUserRegisterationAsync(TblUserRegistration record)
        {
              _context.tblUserRegistration.Add(record);
            _context.SaveChanges();
            return record;
        }

        public async Task<IEnumerable<TblCity>> GetTblCityAsync(int stateId)
        {
            return await _context.tblCity.Where(x=>x.StateId==stateId).ToListAsync();
        }

        public async Task<IEnumerable<TblState>> GetTblStateAsync()
        {
            return await _context.tblState.ToListAsync();
        }

        public async Task<IEnumerable<TblUserRegistration>> GetTblUserRegistrationsAsync()
        {
            return await _context.tblUserRegistration.ToListAsync();
        }
    }
}
