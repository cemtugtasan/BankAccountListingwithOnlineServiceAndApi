using BankAccountProject.Dtos;
using BankAccountProject.Entities;

namespace BankAccountProject.Services.Interfaces
{
    public interface IBankAccountService
    {
        Task<List<BankAccountDto>> GetAllBankAccountsAsync();
        Task AddBankAccountAsync(BankAccountDto bankAccount);
        Task UpdateBankAccountAsync(BankAccountDto bankAccount);
        Task<BankAccount> UpdateAsync(BankAccount entity);
    }
}