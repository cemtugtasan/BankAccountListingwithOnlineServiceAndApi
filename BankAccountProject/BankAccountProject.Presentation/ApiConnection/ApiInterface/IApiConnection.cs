using BankAccountProject.Dtos;

namespace BankAccountProject.Presentation.ApiConnection.ApiInterface
{
    public interface IApiConnection
    {
        Task<List<BankAccountDto>> GetBankAccounts();
    }
}
