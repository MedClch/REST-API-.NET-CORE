using WebApplication1.DTOs.Employees;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{

    public interface IEmployeeService
    {
        Task<EmployeeDTO> getById(int id);
        Task<EmployeeDTO> getByCin(string cin);
        Task<List<EmployeeDTO>> getAll();
        Task<bool> create(EmployeeDTO employeeDTO);
        Task<bool> update(int id, EditEmployeeDTO editEmployeeDTO);
        Task<bool> patch(int id, PatchEmployeeDTO patchEmployeeDTO);
        Task<bool> delete(int id);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> create(EmployeeDTO employeeDTO)
        {
            return await _repository.create(employeeDTO);
        }

        public async Task<bool> delete(int id)
        {
            return await _repository.delete(id);
        }

        public async Task<List<EmployeeDTO>> getAll()
        {
            return await _repository.getAll();
        }

        public async Task<EmployeeDTO> getByCin(string cin)
        {
            return await _repository.getByCin(cin);
        }

        public async Task<EmployeeDTO> getById(int id)
        {
            return await _repository.getById(id);
        }

        public async Task<bool> patch(int id, PatchEmployeeDTO patchEmployeeDTO)
        {
            return await _repository.patch(id,patchEmployeeDTO);
        }

        public async Task<bool> update(int id, EditEmployeeDTO editEmployeeDTO)
        {
            return await _repository.update(id, editEmployeeDTO);
        }
    }
}
