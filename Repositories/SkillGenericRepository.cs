using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    public interface ISkillRepository: IRepository<Skill>
    {
        public Skill FindBySkillCode(string skillCode);
    }
    public class SkillGenericRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillGenericRepository(RecruitmentContext context) : base(context)
        {
        }

        public Skill FindBySkillCode(string skillCode)
        {
            var skill = this.Context.Skills
                .Where(s => s.CSkillCode.Equals(skillCode))
                .FirstOrDefault();

            return skill;
        }

    }
}
