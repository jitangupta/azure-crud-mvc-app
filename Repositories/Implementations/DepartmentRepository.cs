using AzureCrudMvcApp.Context;
using AzureCrudMvcApp.Models;
using AzureCrudMvcApp.Repositories.Declarations;
using Microsoft.EntityFrameworkCore;

namespace AzureCrudMvcApp.Repositories.Implementations
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AzureCrudMvcAppDbContext _context;
        public DepartmentRepository(AzureCrudMvcAppDbContext context)
        {
            _context = context;
        }

        public async Task<Department> Create(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task Delete(Department department)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var item = await GetById(id);
            await Delete(item);
        }

        public async Task<List<Department>> GetAll()
        {
            try
            {
                var result = _context.Departments.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public async Task<Department> GetById(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null)
                throw new Exception();
            return dept;
        }

        public async Task Update(Department department)
        {
            var item = await GetById(department.Id);
            item.Name = department.Name;
            _context.Departments.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
