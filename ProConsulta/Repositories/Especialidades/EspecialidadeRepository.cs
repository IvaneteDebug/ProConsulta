﻿using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Especialidades
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private ApplicationDbContext _context;

        public EspecialidadeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Especialidade>> GetAllAsync()
        {
            return await _context.Especialidades
                .Include(x => x.Medicos)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
