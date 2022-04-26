using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    public interface IPositionRepository : IRepository<Position>
    {
        public Position FindByCode(string positionCode);
    }
    public class PositionGenericRepository : GenericRepository<Position>, IPositionRepository
    {
        public PositionGenericRepository(RecruitmentContext context) : base(context)
        {
        }

        public Position FindByCode(string positionCode)
        {
            var position = this.Context.Positions
                .Where(p => p.CPositionCode.Equals(positionCode))
                .FirstOrDefault();

            return position;
        }
    }
}
