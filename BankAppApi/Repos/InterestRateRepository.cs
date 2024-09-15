﻿using BankAppApi.Data;
using BankAppApi.Entities;
using BankAppApi.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankAppApi.Repos
{
    public class InterestRateRepository : IInterestRateRepository
    {
        private readonly BankContext _context;
        public InterestRateRepository(BankContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InterestRate>> GetAllRatesAsync()
        {
            return await _context.InterestRates.ToListAsync();
        }

        public async Task<InterestRate> GetRateByIdAsync(int id)
        {
            return await _context.InterestRates.FindAsync(id);
        }

        public async Task<bool> AddRateAsync(InterestRate rate)
        {
            _context.InterestRates.Add(rate);
            return await SaveAsync();
        }

        public async Task<bool> UpdateRateAsync(InterestRate rate)
        {
            _context.InterestRates.Update(rate);
            return await SaveAsync();
        }

        public async Task<bool> DeleteRateAsync(int id)
        {
            var rate = await _context.InterestRates.FindAsync(id);
            if (rate == null) return false;
            _context.InterestRates.Remove(rate);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
