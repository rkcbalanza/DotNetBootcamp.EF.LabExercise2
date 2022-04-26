using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
    }
    public class GenericRepository<T> where T : BaseEntity
    {
        public RecruitmentContext Context { get; set; }

        public GenericRepository(RecruitmentContext context)
        {
            this.Context = context;
        }
    }
}
