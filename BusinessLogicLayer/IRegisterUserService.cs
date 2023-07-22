using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IRegisterUserService
    {

        Task<IEnumerable<TblUserRegistration>> GetTblUserRegistrationsAsync();
        Task<TblUserRegistration> AddTblUserRegisterationAsync(TblUserRegistration record);
        Task<IEnumerable<TblState>> GetTblStateAsync();
        Task<IEnumerable<TblCity>> GetTblCityAsync(int stateId);
    }
}
