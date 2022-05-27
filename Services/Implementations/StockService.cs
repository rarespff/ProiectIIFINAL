using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using ProiectII.EF.ViewModels;
using ProiectII.Services.Interfaces;

namespace ProiectII.Services.Implementations
{
    public class StockService : IStockService
    {
        private readonly IIDatabaseDbContext context;
        private readonly IStockRepository stockRepository;
        private readonly IProductRepository productRepository;

        public StockService(IIDatabaseDbContext context, IStockRepository stockRepository,
                            IProductRepository productRepository)
        {
            this.context = context;
            this.stockRepository=stockRepository;
            this.productRepository=productRepository;
        }
        public async Task<String> AddStockToProduct(Stock stock)
        {
            return await stockRepository.AddStockToProduct(stock);
        }


        public async Task<StockEntryVM> EditStock(Stock stock)
        {
            Stock stockFind=await stockRepository.EditStock(stock);
            Product product= await productRepository.GetProductById(stockFind.ProductId);
            StockEntryVM StockEntryVM=new StockEntryVM(stock,product.Name);
            return StockEntryVM;
        }

        public async Task<String> DeleteStock(string productName, int size)
        {
            var product=await productRepository.GetProductByName(productName);
            return await stockRepository.DeleteStock(product.Id, size);
        }

        public async Task<Int32> GetSmallestPriceByProductId(int productId)
        {
            return await stockRepository.GetSmallestPriceForProduct(productId);
        }

        public async Task<IEnumerable<StockEntryVM>> GetStocks()
        {
            IEnumerable<Stock> stocks= await stockRepository.GetStocks();
            return stocks.Select(stock => new StockEntryVM(stock, productRepository.GetProductById(stock.ProductId).Result.Name));
        }

        public async Task<String> AlterStock(int productId, int size, int quantity)
        {
            if(quantity<0)
            {
                await this.RemoveStock(productId,size,quantity);
                return "Ok";
            }
            else
            {
                await this.AddStock(productId,size,quantity);
                return "Ok";
            }
        }

        public async Task<String> RemoveStock(int productId, int size, int quantity)
        {
            StockVM stockVM = new StockVM(productId, size);
            Stock stock = await stockRepository.GetStockByProductIdAndSize(stockVM);
            if(stock != null)
            {
                stock.Quantity=stock.Quantity-Math.Abs(quantity);
                if(stock.Quantity<0)
                {
                    return "Stock should not ne negative";
                }
            }
            await context.SaveChangesAsync();
            return "Ok";
        }

        public async Task<String> AddStock(int productId, int size, int quantity)
        {
            StockVM stockVM = new StockVM(productId, size);
            Stock stock = await stockRepository.GetStockByProductIdAndSize(stockVM);
            stock.Quantity = stock.Quantity + quantity;
            await context.SaveChangesAsync();
            return "Ok";
        }


    }
}
