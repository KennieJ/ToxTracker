using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToxTracker.Data;
using ToxTracker.Models.StandardModels;

namespace ToxTracker.Services
{
    public class StandardService
    {
        private readonly Guid _userId;
        public StandardService(Guid userId)
        {
            _userId = userId;
        }
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //Create
        public bool CreateStandard(StandardCreate model)
        {
            Standard entity = new Standard
            {
                Name = model.Name,
                Concentration = model.Concentration,
                Unit = model.Unit,
                LotNumber = model.LotNumber,
                CatNumber = model.CatNumber,
                IsDeuterated = model.IsDeuterated,
                OpenDate = model.OpenDate,
                RecDate = model.RecDate,
                ExpireDate = model.ExpireDate
            };

            _context.Standards.Add(entity);
            return _context.SaveChanges() == 1;
        }

        //Get all
        public List<StandardListItem> GetAllStandards()
        {
            var standardEntities = _context.Standards.ToList();
            var standardList = standardEntities.Select(s => new StandardListItem
            {
                Id = s.Id,
                Name = s.Name,
                Concentration = s.Concentration,
                Unit = s.Unit,
                RecDate = s.RecDate
            }).ToList();
            return standardList;
        }

        //Get details by ID (update model)
        public StandardListItem GetStandardById(int standardId)
        {
            var standardEntity = _context.Standards.Find(standardId);
            if (standardEntity == null)
                return null;

            var standardDetail = new StandardListItem
            {
                Id = standardEntity.Id,
                Name = standardEntity.Name,
                Concentration = standardEntity.Concentration,
                Unit = standardEntity.Unit,
                IsDeuterated = standardEntity.IsDeuterated,
                LotNumber = standardEntity.LotNumber,
                CatNumber = standardEntity.CatNumber,
                RecDate = standardEntity.RecDate,
                OpenDate = standardEntity.OpenDate,
                ExpireDate = standardEntity.ExpireDate
            };
            return standardDetail;
        }

        public bool UpdateStandard(StandardEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Standards
                        .Single(e => e.Id == model.Id);

                entity.Name = model.Name;
                entity.Concentration = model.Concentration;
                entity.Unit = model.Unit;
                entity.LotNumber = model.LotNumber;
                entity.CatNumber = model.CatNumber;
                entity.IsDeuterated = model.IsDeuterated;
                entity.OpenDate = model.OpenDate;
                entity.RecDate = model.RecDate;
                entity.ExpireDate = model.ExpireDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStandard(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Standards
                        .Single(e => e.Id == id);
                ctx.Standards.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
