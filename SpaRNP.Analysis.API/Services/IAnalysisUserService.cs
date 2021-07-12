using SpaRNP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaRNP.Analysis.API.Services
{
    public interface IAnalysisUserService
    {
        Task<IEnumerable<AnalysisUser>> GetAll();
        Task Save(List<AnalysisUser> users);
        decimal Calculate();
    }
}
