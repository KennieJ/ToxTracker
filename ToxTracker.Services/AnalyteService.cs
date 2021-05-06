using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToxTracker.Data;
using ToxTracker.Models.AnalyteModels;

namespace ToxTracker.Services
{
    public class AnalyteService
    {
        private readonly Guid _userId;
        public AnalyteService(Guid userId)
        {
            _userId = userId;
        }
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //Create
        public bool CreateAnalyte(AnalyteCreate model, int standardId, int stockId)
        {
            Analyte entity = new Analyte
            {
                StandardId = standardId,
                StockId = stockId
            };

            _context.Analytes.Add(entity);
            return _context.SaveChanges() == 1;
        }

        //Get all
        public List<AnalyteListItem> GetAllAnalytes()
        {
            var analyteEntities = _context.Analytes.ToList();
            var analyteList = analyteEntities.Select(a => new AnalyteListItem
            {
                Id = a.Id,
                StandardId = a.StandardId,
                StockId = a.StockId,
                StandardName = a.Standard.Name,
                StockName = a.Stock.Assay

            }).ToList();
            return analyteList;
        }

        //Get by Id
        public AnalyteListItem GetAnalyteById(int? analyteId)
        {
            var analyteEntity = _context.Analytes.Find(analyteId);
            if (analyteId == null)
                return null;

            var analyteDetail = new AnalyteListItem
            {
                Id = analyteEntity.Id,
                StandardName = analyteEntity.Standard.Name,
                StockName = analyteEntity.Stock.Assay
            };
            return analyteDetail;

        }

        public bool UpdateAnalyte(AnalyteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Analytes
                        .Single(e => e.Id == model.Id);

                entity.StandardId = model.StandardId;
                entity.StockId = model.StockId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAnalyte(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Analytes
                        .Single(e => e.Id == id);
                ctx.Analytes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
