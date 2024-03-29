﻿using Rentfy.Data.Configuration;
using Rentfy.Domain.Entities;
using Rentfy.Domain.InterfacesRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentfy.Data.Repositories
{
    public class ObjetoTesteRepository : BaseRepository<ObjetoTeste>, IObjetoTesteRepository
    {
        public ObjetoTesteRepository(RentfyContext context) : base(context) { }

        public async Task AddObject(ObjetoTeste objeto)
        {
            await _context.AddAsync(objeto);
        }

        public async Task DeleteObject(ObjetoTeste objeto)
        {
            await Task.Run(() => _context.Remove(objeto));
        }

        public async Task<ObjetoTeste> GetById(long id)
        {
            return await _context.ObjetoTestes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ObjetoTeste>> ListObjects()
        {
            return await _context.ObjetoTestes.ToListAsync();
        }

        public async Task Update(ObjetoTeste objeto)
        {
            await Task.Run(() => _context.Update(objeto));
        }
    }
}
