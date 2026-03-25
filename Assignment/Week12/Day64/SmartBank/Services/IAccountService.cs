using SmartBank.DTOs;
//using SmartBank.DTOs;
//using SmartBank.Repositories;
//using SmartBank.Models;
//using SmartBank.Exceptions;
//using SmartBank.Helpers;
namespace SmartBank.Services
{
    public interface IAccountService
    {

        Task<AccountDto> CreateAccountAsync(CreateAccountDto dto);
        Task<List<AccountDto>> GetAllAsync();
        Task<AccountDto> GetByIdAsync(int id);
        Task DepositAsync(TransactionDto dto);
        Task WithdrawAsync(TransactionDto dto);
    }
}
