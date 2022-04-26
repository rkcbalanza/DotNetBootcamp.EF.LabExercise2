using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    public interface IMonthlySalaryRepository: IRepository<MonthlySalary>
    {
        public IEnumerable<MonthlySalary> FindByEmployeeCode(string employeeCode);
    }
    public class MonthlySalaryGenericRepository : GenericRepository<MonthlySalary>, IMonthlySalaryRepository
    {
        public MonthlySalaryGenericRepository(RecruitmentContext context) : base(context)
        {
        }

        public IEnumerable<MonthlySalary> FindByEmployeeCode(string employeeCode)
        {
            var monthlySalary = this.Context.MonthlySalaries
                .Where(ms => ms.CEmployeeCode.Equals(employeeCode))
                .ToList();

            return monthlySalary;
        }
    }
}
