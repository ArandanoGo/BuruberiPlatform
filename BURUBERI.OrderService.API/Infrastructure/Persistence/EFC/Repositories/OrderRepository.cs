using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BURUBERI.OrderService.API.Domain.Model.Aggregates;
using BURUBERI.OrderService.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BURUBERI.OrderService.API.Infrastructure.Persistence.EFC.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) =>
            _context = context;

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _context.Orders.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Order>> GetByDistribuidorAsync(int idDistribuidor) =>
            await _context.Orders
                .AsNoTracking()
                .Where(o => o.IdDistribuidor == idDistribuidor)
                .ToListAsync();

        public async Task<IEnumerable<Order>> GetByLoteAsync(string idLote) =>
            await _context.Orders
                .AsNoTracking()
                .Where(o => o.IdLote == idLote)
                .ToListAsync();

        public async Task<Order> AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return;
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order?> GetByIdAsync(int id) =>
            await _context.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
    }
}