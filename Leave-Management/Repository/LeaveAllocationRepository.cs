﻿using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public bool Create(LeaveAllocation entity)
        {
            _db.leaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.leaveAllocations.Remove(entity);
            return Save();
        }

        public ICollection<LeaveAllocation> Findall()
        {
            return _db.leaveAllocations.ToList();
        }

        public LeaveAllocation FindById(int id)
        {
            return _db.leaveAllocations.Find(id);
        }

        public bool IsExists(int id)
        {
            //lambda expression: left side is a temporary variable to store the preceding object, on the right we manipulate this objetcs properties, methods, etc.
            var exists = _db.leaveAllocations.Any(q => q.LeaveTypeId == id);
            return exists;
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
            
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.Update(entity);
            return Save();
        }
    }
}
