using AutoMapper;
using BankAccountProject.DbConnection;
using BankAccountProject.Dtos;
using BankAccountProject.Entities;
using BankAccountProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankAccountProject.Services.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public BankAccountService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddBankAccountAsync(BankAccountDto bankAccount)
        {
            var entiy = _mapper.Map<BankAccount>(bankAccount);
            await _dbContext.AddAsync(entiy);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<BankAccountDto>> GetAllBankAccountsAsync()
        {
            var bankAccounts = await _dbContext.BankAccounts.AsNoTracking().ToListAsync();
            List<BankAccountDto> bAList = bankAccounts.Select(x => _mapper.Map<BankAccountDto>(x)).ToList();
            return bAList;
        }

        public async Task UpdateBankAccountAsync(BankAccountDto bankAccount)
        {
            var needUpdate = await _dbContext.BankAccounts.AsNoTracking().FirstAsync(x => x.id == bankAccount.id);
            if (needUpdate is null)
            {
                throw new Exception(message: "Bank Account was not found!");
            }
            var entity = _mapper.Map<BankAccount>(bankAccount);
            await UpdateAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<BankAccount> UpdateAsync(BankAccount entity)
        {
            var entry = await Task.FromResult(_dbContext.Update(entity));
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }
    }
}