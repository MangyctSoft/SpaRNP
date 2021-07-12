using SpaRNP.Context.Repositories;
using SpaRNP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaRNP.Analysis.API.Services
{
    public class AnalysisUserServiceMock : IAnalysisUserService
    {
       

        private List<AnalysisUser> mock = new List<AnalysisUser>
        {
            new () {Id = 1, RegisteredAt = new DateTime(2021, 3, 8), ActiveAt = new DateTime(2021, 3,15) },
            new () {Id = 2, RegisteredAt = new DateTime(2021, 3, 15), ActiveAt = new DateTime(2021, 3,15) },
            new () {Id = 3, RegisteredAt = new DateTime(2021, 3, 10), ActiveAt = new DateTime(2021, 3,10) },
            new () {Id = 4, RegisteredAt = new DateTime(2021, 3, 11), ActiveAt = new DateTime(2021, 3,11) },
            new () {Id = 5, RegisteredAt = new DateTime(2021, 3, 12), ActiveAt = new DateTime(2021, 3,12) },

        };

        public AnalysisUserServiceMock()
        {
            
        }

        public decimal Calculate()
        {
            decimal a = mock.Count(c => c.ActiveAt >= DateTime.Now.AddDays(-7));
            decimal b = mock.Count(c => c.RegisteredAt <= DateTime.Now.AddDays(-7));

            if (a > 0)
            {
                return a / b * 100;
            }
            return 0;
        }

        public async Task<IEnumerable<AnalysisUser>> GetAll()
        {
            await Task.Yield();
            return mock;
        }



        public async Task Save(List<AnalysisUser> users)
        {
            await Task.Yield();  
            foreach (var item in users)
            {
                var x = mock.FirstOrDefault(c => c.Id == item.Id);
                if (x != null)
                {
                    x.ActiveAt = item.ActiveAt;
                    x.RegisteredAt = item.RegisteredAt;
                }
            }          
        }
    }
}
