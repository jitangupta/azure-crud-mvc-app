using AzureCrudMvcApp.Models;
using AzureCrudMvcApp.Repositories.Declarations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AzureCrudMvcApp.Pages
{
    public class EmployeeModel : PageModel
    {
        private readonly ILogger<EmployeeModel> _logger;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;

        [BindProperty]
        public string Department { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public DateTime DateOfJoining { get; set; }

        public List<SelectListItem> Departments { get; set; }

        public List<Employee> Employees { get; set; }

        public EmployeeModel(ILogger<EmployeeModel> logger, IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            ResetForm();
        }
        public async void OnGet()
        {
            var departments = await _departmentRepository.GetAll();
            Departments = departments.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            Employees = await _employeeRepository.GetAll();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _employeeRepository.Create(new Employee() { Name = Name, DateOfJoining = DateOfJoining, DeptId = Convert.ToInt32(Department) });
                Employees = await _employeeRepository.GetAll();
                ResetForm();
                return Page();
            }
            else
            {

                return Page();
            }

        }

        private void ResetForm()
        {
            Name = "";
            Department = "";
            DateOfJoining = DateTime.Now;
        }
    }
}
