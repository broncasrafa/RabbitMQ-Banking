using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankingRabbitMQ.Service.Banking.Application.DTOs;
using BankingRabbitMQ.Service.Banking.Application.Interfaces;


namespace BankingRabbitMQ.Service.Banking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public BankingController(IAccountService accountService)
        {
            _accountService = accountService;
        }



        /// <summary>
        /// Gets a list of accounts
        /// </summary>
        /// <returns>The collection of accounts registered</returns>
        [HttpGet]
        [ProducesResponseType(typeof(AccountDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<AccountDTO>> Get()
        {
            return Ok(_accountService.GetAccounts());
        }



        /// <summary>
        /// Realize a transfer between accounts
        /// </summary>
        /// <param name="accountTransfer">object that represents an account transfer</param>
        [HttpPost]
        [ProducesResponseType(typeof(AccountTransferDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] AccountTransferDTO accountTransfer)
        {
            _accountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
