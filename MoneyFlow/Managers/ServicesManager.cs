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
            var affected_rows = _dbContext.SaveChanges();
            return affected_rows;
        }  

        public ServiceVM GetById(int id)
        {
            var entity = _dbContext.Service.Find(id);
            var model = new ServiceVM
            {
                ServiceId = id,
                Name = entity.Name,
                Type = entity.Type
            };
            return model;
        }

        public int Edit(ServiceVM model)
        {
            var entity = _dbContext.Service.Find(model.ServiceId);
            entity.Name = model.Name;
            entity.Type = model.Type;

            _dbContext.Service.Update(entity);
            var affected_rows = _dbContext.SaveChanges();
            return affected_rows;

        }

        public int Delete (int id )
        {
            var entity = _dbContext.Service.Find(id);

            _dbContext.Service.Remove(entity);
            var affected_rows = _dbContext.SaveChanges();
            return affected_rows;
        }

        

        
            
            



    }
}

