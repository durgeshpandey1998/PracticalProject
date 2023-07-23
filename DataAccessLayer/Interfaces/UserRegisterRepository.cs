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
            _context = context;
        }
        public async Task<TblUserRegistration> AddTblUserRegisterationAsync(TblUserRegistration record)
        {
            if (record.Id > 0)
            {
                var userData = await GetUserById(record.Id);
                if (userData != null)
                {
                    foreach (var item in userData)
                    {
                        item.StateId = record.StateId;
                        item.CityId = record.CityId;
                        item.Email = record.Email;
                        item.Address = record.Address;
                        item.Name = record.Name;
                        item.Phone = record.Phone;
                        _context.tblUserRegistration.Update(item);
                        _context.SaveChanges();
                    }
                }
                return record;
            }
            else
            {
                _context.tblUserRegistration.Add(record);
                _context.SaveChanges();
                return record;
            }
        }

        public async Task<IEnumerable<TblCity>> GetTblCityAsync(int stateId)
        {
            return await _context.tblCity.Where(x => x.StateId == stateId).ToListAsync();
        }

        public async Task<IEnumerable<TblState>> GetTblStateAsync()
        {
            return await _context.tblState.ToListAsync();
        }

        public async Task<IEnumerable<TblUserRegistration>> GetTblUserRegistrationsAsync()
        {
            return await _context.tblUserRegistration.ToListAsync();
        }

        public async Task<IEnumerable<TblUserRegistration>> GetUserById(int userId)
        {
            return await _context.tblUserRegistration.Where(x => x.Id == userId).ToListAsync();
        }

        public async Task<bool> UserDeletedAsync(int userId)
        {
            var data = await GetUserById(userId);
            foreach (var item in data)
            {
                _context.tblUserRegistration.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
            
        }
    }
}
