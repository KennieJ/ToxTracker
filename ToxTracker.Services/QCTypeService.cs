using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToxTracker.Data;
using ToxTracker.Models.QCTypeModels;

namespace ToxTracker.Services
{
    public class QCTypeService
    {
        private readonly Guid _userId;
        public QCTypeService(Guid userId)
        {
            _userId = userId;
        }
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //Create
        public bool CreateQCType(QCTypeCreate model, int analyteId)
        {
            QCType entity = new QCType
            {
                Level = model.Level,
                Concentration = model.Concentration,
                Unit = model.Unit,
                AnalyteId = analyteId
            };

            _context.QCTypes.Add(entity);
            return _context.SaveChanges() == 1;
        }

        //Get all
        public List<QCTypeListItem> GetAllQCTypes()
        {
            var qcTypeEntities = _context.QCTypes.ToList();
            var qcTypeList = qcTypeEntities.Select(q => new QCTypeListItem
            {
                Id = q.Id,
                Level = q.Level,
                Concentration = q.Concentration,
                Unit = q.Unit,
                AnalyteId = q.AnalyteId,
                AnalyteName = q.Analyte.Standard.Name,
                AssayName = q.Analyte.Stock.Assay
            }).ToList();
            return qcTypeList;
        }

        //Get by Id
        public QCTypeListItem GetQCTypeById(int qcId)
        {
            var qcEntity = _context.QCTypes.Find(qcId);
            if (qcEntity == null)
                return null;

            var qcDetail = new QCTypeListItem
            {
                Id = qcEntity.Id,
                Level = qcEntity.Level,
                Concentration = qcEntity.Concentration,
                Unit = qcEntity.Unit,
                AnalyteId = qcEntity.AnalyteId,
                AnalyteName = qcEntity.Analyte.Standard.Name,
                AssayName = qcEntity.Analyte.Stock.Assay
            };
            return qcDetail;

        }

        public bool UpdateQCType(QCTypeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .QCTypes
                        .Single(e => e.Id == model.Id);

                entity.Level = model.Level;
                entity.Concentration = model.Concentration;
                entity.Unit = model.Unit;
                entity.AnalyteId = model.AnalyteId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteQCType(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .QCTypes
                        .Single(e => e.Id == id);
                ctx.QCTypes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
