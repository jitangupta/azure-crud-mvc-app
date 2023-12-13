using AzureCrudMvcApp.Models;

namespace AzureCrudMvcApp.Repositories.Declarations
{
    public interface IDepartmentRepository
    {
        Task<Department> GetById(int id);
        Task<List<Department>> GetAll();
        Task DeleteById(int id);
        Task Delete(Department employee);
        Task<Department> Create(Department employee);
        Task Update(Department employee);
    }
}
