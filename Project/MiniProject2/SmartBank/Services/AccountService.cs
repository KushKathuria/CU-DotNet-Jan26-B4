
using SmartBank.DTOs;
using SmartBank.Helper;
using SmartBank.Models;
using SmartBank.Repositories;
using SmartBank.Services;
using SmartBank.Exceptions;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repo;

    public AccountService(IAccountRepository repo)
    {
        _repo = repo;
    }

    public async Task<AccountDto> CreateAccountAsync(CreateAccountDto dto)
    {
        if (dto.InitialDeposit < 1000)
            throw new CustomExceptions.BadRequestException("Minimum deposit is ₹1000");

        var account = new Account
        {
            Name = dto.Name,
            Balance = dto.InitialDeposit,
            CreatedAt = DateTime.UtcNow
        };

        var created = await _repo.CreateAsync(account);

        created.AccountNumber = AccountNumberGenerator.Generate(created.Id);
        await _repo.UpdateAsync(created);

        return Map(created);
    }

    public async Task<List<AccountDto>> GetAllAsync()
    {
        var accounts = await _repo.GetAllAsync();
        return accounts.Select(Map).ToList();
    }

    public async Task<AccountDto> GetByIdAsync(int id)
    {
        var account = await _repo.GetByIdAsync(id);
        if (account == null)
            throw new CustomExceptions.NotFoundException("Account not found");

        return Map(account);
    }

    public async Task DepositAsync(TransactionDto dto)
    {
        var account = await _repo.GetByIdAsync(dto.AccountId)
            ?? throw new CustomExceptions.NotFoundException("Account not found");

        if (dto.Amount <= 0)
            throw new CustomExceptions.BadRequestException("Invalid amount");

        account.Balance += dto.Amount;
        await _repo.UpdateAsync(account);
    }

    public async Task WithdrawAsync(TransactionDto dto)
    {
        var account = await _repo.GetByIdAsync(dto.AccountId)
            ?? throw new CustomExceptions.NotFoundException("Account not found");

        if (dto.Amount <= 0)
            throw new  CustomExceptions.BadRequestException("Invalid amount");

        if (account.Balance - dto.Amount < 1000)
            throw new CustomExceptions.BadRequestException("Minimum balance violation");

        account.Balance -= dto.Amount;
        await _repo.UpdateAsync(account);
    }

    private AccountDto Map(Account a) => new AccountDto
    {
        Id = a.Id,
        AccountNumber = a.AccountNumber,
        Name = a.Name,
        Balance = a.Balance
    };
}