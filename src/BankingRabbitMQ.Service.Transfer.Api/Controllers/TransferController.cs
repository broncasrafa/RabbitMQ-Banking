using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankingRabbitMQ.Service.Transfer.Application.DTOs;
using BankingRabbitMQ.Service.Transfer.Application.Interfaces;


namespace BankingRabbitMQ.Service.Transfer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }


        /// <summary>
        /// Gets a list of registered tranfers
        /// </summary>
        /// <returns>The collection of tranfers registered</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TransferLogDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<TransferLogDTO>> Get()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}
