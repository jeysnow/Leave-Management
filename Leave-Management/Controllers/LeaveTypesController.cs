using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Leave_Management.Contracts;
using Leave_Management.Data;
using Leave_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leave_Management.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _Mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _Mapper = mapper;
            _repo = repo;

        }


        // GET: LEaveTypesController1
        public ActionResult Index()
        {
            var leaveTypes = _repo.Findall().ToList();
            var model = _Mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leaveTypes);
            return View(model);
        }

        // GET: LEaveTypesController1/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExists(id))
                return NotFound();
            var leaveType = _repo.FindById(id);
            var model = _Mapper.Map<LeaveTypeVM>(leaveType);

            return View(model);
        }

        // GET: LEaveTypesController1/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: LEaveTypesController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                //_mapper.map converts model into leavetype
                var leavetype = _Mapper.Map<LeaveType>(model);

                leavetype.DateCreated = DateTime.Now;

                if (!_repo.Create(leavetype))
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model);
                }
                    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
        }

        // GET: LEaveTypesController1/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExists(id))
                return NotFound();

            var leavetype = _repo.FindById(id);
            //_mapper.map converts leavetype into leavetypeVM
            var model = _Mapper.Map<LeaveTypeVM>(leavetype);
            return View(model);
        }

        // POST: LEaveTypesController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var leavetype = _Mapper.Map<LeaveType>(model);
                var isSuccess = _repo.Update(leavetype);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View();
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }

        // GET: LEaveTypesController1/Delete/5
        public ActionResult Delete(int id)
        {
            if (!_repo.IsExists(id))
                return NotFound();

            var leavetype = _repo.FindById(id);
            //_mapper.map converts leavetype into leavetypeVM
            var model = _Mapper.Map<LeaveTypeVM>(leavetype);
            return View(model);
            
        }

        // POST: LEaveTypesController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LeaveTypeVM model)
        {
            try
            {
                if (!_repo.IsExists(id))
                    return NotFound();

                var leavetype = _repo.FindById(id);
                var isSuccess = _repo.Delete(leavetype);
                if (!isSuccess)
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));



            }
            catch
            {
                return View();
            }
        }
    }
}
