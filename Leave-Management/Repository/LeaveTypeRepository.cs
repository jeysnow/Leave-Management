using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public bool Create(LeaveType entity)
        {
            _db.leaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.leaveTypes.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> Findall()
        {
            return _db.leaveTypes.ToList();
        }

        public LeaveType FindById(int id)
        {
            return _db.leaveTypes.Find(id);
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            //o operador boleano avalia a questão e retorna true or false
            return _db.SaveChanges() > 0;
            
        }

        public bool Update(LeaveType entity)
        {
            _db.leaveTypes.Update(entity);
            return Save();
        }
    }

}
