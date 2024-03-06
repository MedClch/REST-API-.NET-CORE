using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs.Employees;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeDTO> getById(int id);
        Task<EmployeeDTO> getByCin(string cin);
        Task<List<EmployeeDTO>> getAll();
        Task<bool> create(EmployeeDTO employeeDTO);
        Task<bool> update(int id,EditEmployeeDTO editEmployeeDTO);
        Task<bool> patch(int id, PatchEmployeeDTO patchEmployeeDTO);
        Task<bool> delete(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyData _db;
        private readonly IMapper _mapper;
        public EmployeeRepository(MyData db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> create(EmployeeDTO employeeDTO)
        {
            var data = _mapper.Map<Employee>(employeeDTO);
            _db.Employees.Add(data);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> delete(int id)
        {
            var data = await _db.Employees.FirstOrDefaultAsync(x => x.idEmployee==id);
            if (data!=null)
            {
                _db.Employees.Remove(data);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<EmployeeDTO>> getAll()
        {
            var data = await _db.Employees.ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(data);
        }

        public async Task<EmployeeDTO> getByCin(string cin)
        {
            var data = await _db.Employees.FirstOrDefaultAsync(x => x.cin.ToLower().Equals(cin.ToLower()));
            return data != null ? _mapper.Map<EmployeeDTO>(data) : null;
        }

        public async Task<EmployeeDTO> getById(int id)
        {
            var data = await _db.Employees.FirstOrDefaultAsync(x=>x.idEmployee==id);
            return data != null ? _mapper.Map<EmployeeDTO>(data) : null;
        }

        public async Task<bool> patch(int id, PatchEmployeeDTO patchEmployeeDTO)
        {
            var data = await _db.Employees.FirstOrDefaultAsync(x => x.idEmployee==id);
            if (data != null)
            {
                _mapper.Map(patchEmployeeDTO, data);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> update(int id, EditEmployeeDTO editEmployeeDTO)
        {
            var data = await _db.Employees.FirstOrDefaultAsync(x => x.idEmployee==id);
            if (data != null)
            {
                _mapper.Map(editEmployeeDTO, data);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
