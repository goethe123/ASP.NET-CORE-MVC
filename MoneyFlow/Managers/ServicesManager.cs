using Microsoft.EntityFrameworkCore;
using MoneyFlow.Context;
using MoneyFlow.Entities;
using MoneyFlow.Models;

namespace MoneyFlow.Managers
{
    public class ServicesManager(AppDbContext _dbContext)
    {
        public List<ServiceVM> GetAll(int userId)
        {
            var list = _dbContext.Service.Where(item => item.UserId == userId).Select(item => new ServiceVM
            {
                ServiceId = item.ServiceId,
                UserId = item.UserId,
                Name = item.Name,
                Type = item.Type
            }).ToList();

            return list;

        }

        public int New(ServiceVM viewModel)
        {
            var entity = new Service
            {
                Name = viewModel.Name,
                Type = viewModel.Type,
                UserId = viewModel.UserId
            };

            _dbContext.Service.Add(entity);
            var rowsAfected = _dbContext.SaveChanges();
            return rowsAfected;


        }        

        
            
            



    }
}

