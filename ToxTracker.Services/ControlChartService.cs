using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToxTracker.Data;
using ToxTracker.Models.ControlChartModels;

namespace ToxTracker.Services
{
    public class ControlChartService
    {
        private readonly Guid _userId;
        public ControlChartService(Guid userId)
        {
            _userId = userId;
        }
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //Create
        public bool CreateControl(ControlCreate model, int qcId)
        {
            ControlChart entity = new ControlChart
            {
                QuantValue = model.QuantValue,
                RunDate = model.RunDate,
                BatchName = model.BatchName,
                QCId = qcId
            };

            _context.Controls.Add(entity);
            return _context.SaveChanges() == 1;
        }

        //Get all
        public List<ControlListItem> GetAllControls()
        {
            var controlEntities = _context.Controls.ToList();
            var controlList = controlEntities.Select(c => new ControlListItem
            {
                Id = c.Id,
                QuantValue = c.QuantValue,
                RunDate = c.RunDate,
                BatchName = c.BatchName,
                QCId = c.QCId
            }).ToList();
            return controlList;
        }

        //Get by Id
        public ControlListItem GetControlById(int qcId)
        {
            var controlEntity = _context.Controls.Find(qcId);
            if (controlEntity == null)
                return null;

            var controlDetail = new ControlListItem
            {
                Id = controlEntity.Id,
                QuantValue = controlEntity.QuantValue,
                RunDate = controlEntity.RunDate,
                BatchName = controlEntity.BatchName,
                QCId = controlEntity.QCId
            };
            return controlDetail;

        }

        public bool UpdateControl(ControlEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Controls
                        .Single(e => e.Id == model.Id);

                entity.QuantValue = model.QuantValue;
                entity.RunDate = model.RunDate;
                entity.BatchName = model.BatchName;
                entity.QCId = model.QCId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteControl(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Controls
                        .Single(e => e.Id == id);
                ctx.Controls.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
