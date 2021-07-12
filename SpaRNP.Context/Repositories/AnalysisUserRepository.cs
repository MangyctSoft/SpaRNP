using Microsoft.EntityFrameworkCore;
using SpaRNP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaRNP.Context.Repositories
{
    public class AnalysisUserRepository : IAnalysisUsersRepository
    {
        private readonly AnalysisContext _analysisContext;

        public AnalysisUserRepository(AnalysisContext analysisContext)
        {
            _analysisContext = analysisContext;
        }

        public decimal Calculate()
        {
            decimal result1 = _analysisContext.AnalysisUsers.Count(w => w.ActiveAt >= DateTime.Now.AddDays(-7));
            decimal result2 = _analysisContext.AnalysisUsers.Count(w => w.RegisteredAt <= DateTime.Now.AddDays(-7));
            if (result1 > 0 && result2 > 0)
            {
                return result1 / result2 * 100;
            }
            return 0;            
        }
        /// <summary>
        /// Получает список пользователей.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AnalysisUser>> GetAll() => await _analysisContext.AnalysisUsers.ToListAsync();       

        /// <summary>
        /// Обновляет данные пользователей.
        /// </summary>
        /// <param name="users">Массив пользователей</param>
        /// <returns></returns>
        public async Task Save(IEnumerable<AnalysisUser> users)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            _analysisContext.AnalysisUsers.UpdateRange(users);
            await _analysisContext.SaveChangesAsync();            
        }
    }
}
