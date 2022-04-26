using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    public interface IAnnualSalaryRepository: IRepository<AnnualSalary>
    {
        public IEnumerable<AnnualSalary> FindByEmployeeCode(string employeeCode);
    }
    public class AnnualSalaryGenericRepository : GenericRepository<AnnualSalary>, IAnnualSalaryRepository
    {
        public AnnualSalaryGenericRepository(RecruitmentContext context) : base(context)
        {
        }

        public IEnumerable<AnnualSalary> FindByEmployeeCode(string employeeCode)
        {
            var annualSalary = this.Context.AnnualSalaries
                .Where(a => a.CEmployeeCode.Equals(employeeCode))
                .ToList();

            return annualSalary;
        }
    }
}
