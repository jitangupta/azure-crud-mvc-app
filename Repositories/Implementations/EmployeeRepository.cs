using AzureCrudMvcApp.Context;
using AzureCrudMvcApp.Models;
using AzureCrudMvcApp.Repositories.Declarations;
using Microsoft.EntityFrameworkCore;

namespace AzureCrudMvcApp.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AzureCrudMvcAppDbContext _context;
        public EmployeeRepository(AzureCrudMvcAppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Create(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(long id)
        {
            var item = await GetById(id);
            await Delete(item);
        }

        public async Task<List<Employee>> GetAll()
        {
            return _context.Employees.Include(x => x.Dept).ToList();
        }

        public async Task<Employee> GetById(long id)
        {
            var dept = await _context.Employees.FindAsync(id);
            if (dept == null)
                throw new Exception();
            return dept;
        }

        public async Task Update(Employee employee)
        {
            var item = await GetById(employee.Id);
            item.Name = employee.Name;
            item.DeptId = employee.DeptId;
            item.DateOfJoining = employee.DateOfJoining;
            _context.Employees.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
