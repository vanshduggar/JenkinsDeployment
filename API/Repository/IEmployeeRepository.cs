using EmployeeCRUDAPI.Models;

namespace EmployeeCRUDAPI.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(int id,Employee employee);
        Task<Employee> Delete(int id);
    }
}
