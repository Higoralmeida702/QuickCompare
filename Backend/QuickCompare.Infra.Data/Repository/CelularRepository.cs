using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuickCompare.Domain.Entity;
using QuickCompare.Domain.Interfaces;
using QuickCompare.Infra.Data.Data;

namespace QuickCompare.Infra.Data.Repository
{
    public class CelularRepository : ICelularRepository
    {
        private readonly ApplicationDbContext _context;

        public CelularRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CelularEntity> AdicionarCelular(CelularEntity celular)
        {
            await _context.Celulares.AddAsync(celular);
            await _context.SaveChangesAsync();
            return celular;
        }
        
        public async Task<CelularEntity> ObterCelularPorId(int id)
        {
            return await _context.Celulares.FindAsync(id);
        }
    }
}