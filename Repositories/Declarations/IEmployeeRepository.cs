using AzureCrudMvcApp.Models;

namespace AzureCrudMvcApp.Repositories.Declarations
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetById(long id);
        Task<List<Employee>> GetAll();
        Task DeleteById(long id);
        Task Delete(Employee employee);
        Task<Employee> Create(Employee employee);
        Task Update(Employee employee);
    }
}
