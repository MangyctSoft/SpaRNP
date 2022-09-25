using SpaRNP.Context.Repositories;
using SpaRNP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaRNP.Analysis.API.Services
{
    public class AnalysisUserService : IAnalysisUserService
    {
        private readonly IAnalysisUsersRepository _analysisUsersRepository;

        public AnalysisUserService(IAnalysisUsersRepository analysisUserService)
        {
            _analysisUsersRepository = analysisUserService;
        }

        public decimal Calculate() => _analysisUsersRepository.Calculate();

        public Task<IEnumerable<AnalysisUser>> GetAll() => _analysisUsersRepository.GetAll();

        public Task Save(List<AnalysisUser> users) => _analysisUsersRepository.Save(users);
    }
}
