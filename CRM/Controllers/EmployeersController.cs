using CRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Controllers
{
    public class employeersController : Controller
    {
        private readonly CRMDBContext _context;
        public employeersController(CRMDBContext context)
        {
            _context = context;
        }
        #region Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeViewModel model)
        {
            await using (_context)
            {
                _context.Employees.Add(model);
                await _context.SaveChangesAsync();
            }
            return Redirect("/Home/Index");
        }
        #endregion
        #region GetInfo
        public async Task<IActionResult> GetInfo()
        {
            return View(await _context.Employees.ToListAsync());
        }
        #endregion
        #region Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var _model = _context.Employees.SingleAsync(b => b.Id == id);
            return View(_model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeViewModel _model, int? id)
        {
            EmployeeViewModel model = await _context.Employees.FirstOrDefaultAsync(p => p.Id == id);
            await using (_context)
            {
                if (model != null)
                {
                    _context.Attach(model);
                    _context.Remove(model);
                    _context.SaveChanges();
                }
            }
            return Redirect("/Home/Index");
        }
        #endregion
        #region EmployeeInfo
        [HttpGet]
        public async Task<IActionResult> EmployeeInfo()
        {
            Int32.TryParse(Request.Path.Value.Split('/').LastOrDefault(), out int id);
            var _model = _context.Employees.Single(b => b.Id == id);
            return View(_model);
        }

        #endregion
        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return Redirect("/Home/Error");
            var _model = await _context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (_model == null)
                return Redirect("/Home/Error");

            return View(_model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
            _context.Employees.Update(model);
            await _context.SaveChangesAsync();
            return Redirect("/Home/Index");
        }
        
        #endregion

    }
}
