using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartBank.Data;
using SmartBank.DTOs;
using SmartBank.Models;
using SmartBank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBank.Controllers
{

    [ApiController]
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountDto dto)
            => Ok(await _service.CreateAccountAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _service.GetByIdAsync(id));

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(TransactionDto dto)
        {
            await _service.DepositAsync(dto);
            return Ok("Deposit successful");
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(TransactionDto dto)
        {
            await _service.WithdrawAsync(dto);
            return Ok("Withdrawal successful");
        }
    }
}
