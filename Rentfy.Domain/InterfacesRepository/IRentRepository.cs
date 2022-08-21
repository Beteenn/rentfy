﻿using Rentfy.Domain.Entities;
using System.Threading.Tasks;

namespace Rentfy.Domain.InterfacesRepository
{
    public interface IRentRepository : IBaseRepository<Rent>
    {
        Task<Rent> GetById(long id);
        Task Add(Rent rent);
        Task Update(Rent rent);
        Task Delete(Rent rent);
    }
}