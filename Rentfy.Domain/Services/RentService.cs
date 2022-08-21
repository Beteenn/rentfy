﻿using Rentfy.Domain.Entities;
using Rentfy.Domain.Enumerations;
using Rentfy.Domain.Interfaces;
using Rentfy.Domain.InterfacesRepository;
using Rentfy.Domain.SeedWork;
using System;
using System.Threading.Tasks;

namespace Rentfy.Domain.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;

        public RentService(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository ?? throw new ArgumentNullException(nameof(rentRepository));
        }

        public async Task<DomainResult<Rent>> GetById(long id)
        {
            var rent = await _rentRepository.GetById(id);

            return new DomainResult<Rent>(rent);
        }

        public async Task<DomainResult<Rent>> Create(Rent rent)
        {
            await _rentRepository.Add(rent);
            await _rentRepository.UnitOfWork.CommitAsync();

            return new DomainResult<Rent>(rent);
        }

        public async Task<DomainResult> CancelRent(long rentId)
        {
            var rent = await _rentRepository.GetById(rentId);

            if (rent == null) return new DomainResult().AddErrorMessage("Alugel não encontrado.");

            rent.Cancel();

            await _rentRepository.Update(rent);
            await _rentRepository.UnitOfWork.CommitAsync();

            return new DomainResult();
        }

        public async Task<DomainResult> StartRent(long rentId)
        {
            var rent = await _rentRepository.GetById(rentId);

            if (rent == null) return new DomainResult().AddErrorMessage("Alugel não encontrado.");

            if (rent.StatusId == RentStatusEnumeration.Canceled.Id) return new DomainResult().AddErrorMessage("Alugel cancelado.");

            rent.Start();

            await _rentRepository.Update(rent);
            await _rentRepository.UnitOfWork.CommitAsync();

            return new DomainResult();
        }

        public async Task<DomainResult> DeleteById(long id)
        {
            var rent = await _rentRepository.GetById(id);

            if (rent == null) return new DomainResult().AddErrorMessage("Aluguel não encontrado.");

            await _rentRepository.Delete(rent);
            await _rentRepository.UnitOfWork.CommitAsync();

            return new DomainResult();
        }
    }
}
