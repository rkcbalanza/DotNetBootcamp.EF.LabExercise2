using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        public Employee FindByEmployeeCode(string employeeCode);
    }
    public class EmployeeGenericRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeGenericRepository(RecruitmentContext context) : base(context)
        {
        }

        public Employee FindByEmployeeCode(string employeeCode)
        {
            var employee = this.Context.Employees
                .Where(p => p.CEmployeeCode.Equals(employeeCode))
                .FirstOrDefault();

            if (employee != null)
            {
                return employee;
            }
            throw new Exception($"Employee with ID {employeeCode} not found!");
        }
    }
}
