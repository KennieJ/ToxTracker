using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToxTracker.Data;
using ToxTracker.Models.StockModels;

namespace ToxTracker.Services
{
    public class StockService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //Create
        public bool CreateStock(StockCreate model)
        {
            Stock entity = new Stock
            {
                Assay = model.Assay,
                LotNumber = model.LotNumber,
                Type = model.Type,
                IsApproved = model.IsApproved
            };

            _context.Stocks.Add(entity);
            return _context.SaveChanges() == 1;
        }

        //Get all
        public List<StockListItem> GetAllStocks()
        {
            var stockEntities = _context.Stocks.ToList();
            var stockList = stockEntities.Select(s => new StockListItem
            {
                Id = s.Id,
                Assay = s.Assay,
                LotNumber = s.LotNumber,
                Type = s.Type,
                IsApproved = s.IsApproved
            }).ToList();
            return stockList;
        }

        //Get by Id
        public StockListItem GetStockById(int stockId)
        {
            var stockEntity = _context.Stocks.Find(stockId);
            if (stockEntity == null)
                return null;

            var stockDetail = new StockListItem
            {
                Id = stockEntity.Id,
                Assay = stockEntity.Assay,
                LotNumber = stockEntity.LotNumber,
                Type = stockEntity.Type,
                IsApproved = stockEntity.IsApproved
            };
            return stockDetail;

        }
    }
}
