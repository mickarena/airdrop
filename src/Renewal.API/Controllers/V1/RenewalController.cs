using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Renewal.Application.DatabaseServices.Interfaces;
using Renewal.Application.Models.Financial;
using Renewal.Application.Models.ProcessingData;
using Renewal.Application.ResultObjects;

namespace Renewal.API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RenewalController : ControllerBase
    {
        private readonly ILogger<RenewalController> _logger;
        private readonly IPolicyService _policyDataService;
        private readonly IProcessingDataService _processingDataService;
        public RenewalController(ILogger<RenewalController> logger,
                                IPolicyService policyService,
                                IProcessingDataService processingDataService)
        {
            _logger = logger;
            _policyDataService = policyService;
            _processingDataService = processingDataService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VerificationQuestionRequestModel requestModel)
        {
            _logger.LogInformation("Start verification questions V1");

            var response = await _processingDataService.Verification(requestModel);

            if (!response.IsSuccess)
            {
                _logger.LogError(response.PlainTextMessages);
                return BadRequest(response);
            }

            _logger.LogInformation($"End verification questions V1. message: {response.PlainTextMessages}");

            return Ok(response);
        }

        [HttpPost]
        [Route("status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateStatusRequestModel requestModel)
        {
            _logger.LogInformation("Start update status processing data V1");
            var response = await _processingDataService.UpdateStatus(requestModel);

            if (!response.IsSuccess)
            {
                _logger.LogError(response.PlainTextMessages);
                return BadRequest(response);
            }

            _logger.LogInformation($"End update status processing data V1. message: {response.PlainTextMessages}");

            return Ok(response);
        }

        [HttpPost]
        [Route("transaction")]
        public async Task<IActionResult> UpdateTransaction([FromBody] UpdatePaymentTransactionRequestModel requestModel)
        {
            _logger.LogInformation("Start update transaction processing data V1");
            var response = await _processingDataService.UpdateTransactionAsync(requestModel);

            if (!response.IsSuccess)
            {
                _logger.LogError(response.PlainTextMessages);
                return BadRequest(response);
            }

            _logger.LogInformation($"End update transaction processing data V1. message: {response.PlainTextMessages}");

            return Ok(response);
        }

        [HttpPost]
        [Route("payment-method")]
        public async Task<IActionResult> UpdatePaymentMethod([FromBody] UpdatePaymentMethodRequestModel requestModel)
        {
            _logger.LogInformation("Start update payment method processing data V1");
            var response = await _processingDataService.UpdatePaymentMethodAsync(requestModel);

            if (!response.IsSuccess)
            {
                _logger.LogError(response.PlainTextMessages);
                return BadRequest(response);
            }

            _logger.LogInformation($"End update status payment method data V1. message: {response.PlainTextMessages}");

            return Ok(response);
        }

        [HttpPost]
        [Route("bank-account")]
        public async Task<IActionResult> UpdateBankAccount([FromBody] UpdateBankAccountRequestModel requestModel)
        {
            _logger.LogInformation("Start update bank account method processing data V1");
            var response = await _processingDataService.UpdateBankAccountAsync(requestModel);

            if (!response.IsSuccess)
            {
                _logger.LogError(response.PlainTextMessages);
                return BadRequest(response);
            }

            _logger.LogInformation($"End update status bank account method data V1. message: {response.PlainTextMessages}");

            return Ok(response);
        }

        [HttpGet]
        [Route("invites")]
        [Produces(typeof(AbstractResult<FinancialResponseModel>))]
        public async Task<IActionResult> GetPolicyDetails(string policyRef)
        {
            _logger.LogInformation("Start get policy details V1");

            var result = await _policyDataService.GetFinancialByPolicyRef(policyRef);
            if (!result.IsSuccess)
            {
                _logger.LogError(result.PlainTextMessages);
                return BadRequest(result);
            }

            _logger.LogInformation($"End get policy details V1. Message: {result.PlainTextMessages}");

            return Ok(result);
        }

        [HttpPost]
        [Route("verify-payment-infor")]
        public async Task<IActionResult> VerifyPaymentInfor(VerifyPaymentInforRequestModel model)
        {
            _logger.LogInformation("Start verify infor V1");
            var response = await _processingDataService.VerifyPaymentInforAsync(model);

            if (!response.IsSuccess)
            {
                _logger.LogError(response.PlainTextMessages);
                return BadRequest(response);
            }

            _logger.LogInformation($"End verify infor V1. message: {response.PlainTextMessages}");

            return Ok(response);
        }
    }
}