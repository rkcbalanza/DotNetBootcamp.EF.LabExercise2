using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    public interface ICandidateSkillRepository: IRepository<CandidateSkill>
    {
        public IEnumerable<CandidateSkill> FindSkillByCandidateCode(string candidateCode);
    }
    public class CandidateSkillGenericRepository :GenericRepository<CandidateSkill>, ICandidateSkillRepository
    {
        public CandidateSkillGenericRepository(RecruitmentContext context) : base(context)
        {
        }

        public IEnumerable<CandidateSkill> FindSkillByCandidateCode(string candidateCode)
        {
            var filteredSkill = this.Context.CandidateSkills
                .Where(cs => cs.CCandidateCode.Equals(candidateCode))
                .ToList();

            return filteredSkill;
        }
    }
}
