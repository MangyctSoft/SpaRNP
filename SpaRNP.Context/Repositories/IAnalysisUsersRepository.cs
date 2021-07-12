using SpaRNP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaRNP.Context.Repositories
{
    public interface IAnalysisUsersRepository
    {
        Task<IEnumerable<AnalysisUser>> GetAll();
        Task Save(IEnumerable<AnalysisUser> users);        
        decimal Calculate();
    }
}
