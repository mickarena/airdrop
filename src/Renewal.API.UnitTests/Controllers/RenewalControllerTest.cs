using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Renewal.API.Controllers.V1;
using Renewal.Application.DatabaseServices.Interfaces;
using Renewal.Application.Models.Financial;
using Renewal.Application.Models.ProcessingData;
using Renewal.Application.ResultObjects;
using Xunit;

namespace Renewal.API.UnitTests.Controllers
{
    public class RenewalControllerTest
    {
        private readonly Mock<ILogger<RenewalController>> _logger;

        public RenewalControllerTest()
        {
            _logger = new Mock<ILogger<RenewalController>>();
        }

        [Fact]
        public async Task PostVerification_ValidRequest_SuccessResult()
        {
            var model = new ProcessingDataResponseModel
            {
                Id = Guid.NewGuid()
            };

            var mockOnlineRenewalsProcessingDataService = new Mock<IProcessingDataService>();
            var mockPolicyDataService = new Mock<IPolicyService>();

            var returnData = new AppSuccessResult<ProcessingDataResponseModel>(model, "Get verification questions successfully");

            //Arrange
            mockOnlineRenewalsProcessingDataService.Setup(x => x.Verification(It.IsAny<VerificationQuestionRequestModel>())).ReturnsAsync(returnData);
            var renewalController = new RenewalController(_logger.Object, mockPolicyDataService.Object, mockOnlineRenewalsProcessingDataService.Object);

            //Action
            var result = await renewalController.Post(It.IsAny<VerificationQuestionRequestModel>());

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task PostVerification_ValidRequest_BadRequestObjectResult()
        {
            var model = new ProcessingDataResponseModel
            {
                Id = Guid.NewGuid()
            };

            var mockOnlineRenewalsProcessingDataService = new Mock<IProcessingDataService>();
            var mockPolicyDataService = new Mock<IPolicyService>();

            var returnData = new AppErrorResult<ProcessingDataResponseModel>(null, "Sorry, that policy reference number doesn't match our database. Please enter the reference as it appears on the renewal invitation");

            //Arrange
            mockOnlineRenewalsProcessingDataService.Setup(x => x.Verification(It.IsAny<VerificationQuestionRequestModel>())).ReturnsAsync(returnData);
            var renewalController = new RenewalController(_logger.Object, mockPolicyDataService.Object, mockOnlineRenewalsProcessingDataService.Object);

            //Action
            var result = await renewalController.Post(It.IsAny<VerificationQuestionRequestModel>());

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateStatus_ValidRequest_SuccessResult()
        {
            var mockOnlineRenewalsProcessingDataService = new Mock<IProcessingDataService>();
            var mockPolicyDataService = new Mock<IPolicyService>();

            var returnData = new AppSuccessResult<bool>(true);

            //Arrange
            mockOnlineRenewalsProcessingDataService.Setup(x => x.UpdateStatus(It.IsAny<UpdateStatusRequestModel>())).ReturnsAsync(returnData);
            var renewalController = new RenewalController(_logger.Object, mockPolicyDataService.Object, mockOnlineRenewalsProcessingDataService.Object);

            //Action
            var result = await renewalController.UpdateStatus(It.IsAny<UpdateStatusRequestModel>());

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateStatus_ValidRequest_BadRequestObjectResult()
        {
            var mockOnlineRenewalsProcessingDataService = new Mock<IProcessingDataService>();
            var mockPolicyDataService = new Mock<IPolicyService>();


            var returnData = new AppErrorResult<bool>(false);

            //Arrange
            mockOnlineRenewalsProcessingDataService.Setup(x => x.UpdateStatus(It.IsAny<UpdateStatusRequestModel>())).ReturnsAsync(returnData);
            var renewalController = new RenewalController(_logger.Object, mockPolicyDataService.Object, mockOnlineRenewalsProcessingDataService.Object);

            //Action
            var result = await renewalController.UpdateStatus(It.IsAny<UpdateStatusRequestModel>());

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateTransaction_ValidRequest_SuccessResult()
        {
            var mockOnlineRenewalsProcessingDataService = new Mock<IProcessingDataService>();
            var mockPolicyDataService = new Mock<IPolicyService>();

            var returnData = new AppSuccessResult<bool>(true);

            //Arrange
            mockOnlineRenewalsProcessingDataService.Setup(x => x.UpdateTransactionAsync(It.IsAny<UpdatePaymentTransactionRequestModel>())).ReturnsAsync(returnData);
            var renewalController = new RenewalController(_logger.Object, mockPolicyDataService.Object, mockOnlineRenewalsProcessingDataService.Object);

            //Action
            var result = await renewalController.UpdateTransaction(It.IsAny<UpdatePaymentTransactionRequestModel>());

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateTransaction_ValidRequest_BadRequestObjectResult()
        {
            var mockOnlineRenewalsProcessingDataService = new Mock<IProcessingDataService>();
            var mockPolicyDataService = new Mock<IPolicyService>();


            var returnData = new AppErrorResult<bool>(false);

            //Arrange
            mockOnlineRenewalsProcessingDataService.Setup(x => x.UpdateTransactionAsync(It.IsAny<UpdatePaymentTransactionRequestModel>())).ReturnsAsync(returnData);
            var renewalController = new RenewalController(_logger.Object, mockPolicyDataService.Object, mockOnlineRenewalsProcessingDataService.Object);

            //Action
            var result = await renewalController.UpdateTransaction(It.IsAny<UpdatePaymentTransactionRequestModel>());

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_PaymentMethod_ValidRequest_SuccessResult()
        {
            var mockOnlineRenewalsProcessingDataService = new Mock<IProcessingDataService>();
            var mockPolicyDataService = new Mock<IPolicyService>();

            var returnData = new AppSuccessResult<bool>(true);

            //Arrange
            mockOnlineRenewalsProcessingDataService.Setup(x => x.UpdatePaymentMethodAsync(It.IsAny<UpdatePaymentMethodRequestModel>())).ReturnsAsync(returnData);
            var renewalController = new RenewalController(_logger.Object, mockPolicyDataService.Object, mockOnlineRenewalsProcessingDataService.Object);

            //Action
            var result = await renewalController.UpdatePaymentMethod(It.IsAny<UpdatePaymentMethodRequestModel>());

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_PaymentMethod_ValidRequest_BadRequestObjectResult()
        {
            var mockOnlineRenewalsProcessingDataService = new Mock<IProcessingDataService>();
            var mockPolicyDataService = new Mock<IPolicyService>();

            var returnData = new AppErrorResult<bool>(false);

            //Arrange
            mockOnlineRenewalsProcessingDataService.Setup(x => x.UpdatePaymentMethodAsync(It.IsAny<UpdatePaymentMethodRequestModel>())).ReturnsAsync(returnData);
            var renewalController = new RenewalController(_logger.Object, mockPolicyDataService.Object, mockOnlineRenewalsProcessingDataService.Object);

            //Action
            var result = await renewalController.UpdatePaymentMethod(It.IsAny<UpdatePaymentMethodRequestModel>());

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_BankAccount_ValidRequest_SuccessResult()
        {
            var mockOnlineRenewalsProcessingDataService = new Mock<IProcessingDataService>();
            var mockPolicyDataService = new Mock<IPolicyService>();

            var returnData = new AppSuccessResult<bool>(true);

            //Arrange
            mockOnlineRenewalsProcessingDataService.Setup(x => x.UpdateBankAccountAsync(It.IsAny<UpdateBankAccountRequestModel>())).ReturnsAsync(returnData);
            var renewalController = new RenewalController(_logger.Object, mockPolicyDataService.Object, mockOnlineRenewalsProcessingDataService.Object);

            //Action
            var result = await renewalController.UpdateBankAccount(It.IsAny<UpdateBankAccountRequestModel>());

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_BankAccount_ValidRequest_BadRequestObjectResult()
        {
            var mockOnlineRenewalsProcessingDataService = new Mock<IProcessingDataService>();
            var mockPolicyDataService = new Mock<IPolicyService>();

            var returnData = new AppErrorResult<bool>(false);

            //Arrange
            mockOnlineRenewalsProcessingDataService.Setup(x => x.UpdateBankAccountAsync(It.IsAny<UpdateBankAccountRequestModel>())).ReturnsAsync(returnData);
            var renewalController = new RenewalController(_logger.Object, mockPolicyDataService.Object, mockOnlineRenewalsProcessingDataService.Object);

            //Action
            var result = await renewalController.UpdateBankAccount(It.IsAny<UpdateBankAccountRequestModel>());

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        public async Task GetPolicyDetails_ValidRequest_SuccessResult()
        {
            var response = new FinancialResponseModel
            {
                Deposit = 10,
                APR = 10
            };
            var returnData = new AppSuccessResult<FinancialResponseModel>(response,
                                                                          "Get Financial detail successfully");
            var mockPolicyDataService = new Mock<IPolicyService>();
            var mockOnlineRenewalsProcessingDataService = new Mock<IProcessingDataService>();

            //Arrange
            mockPolicyDataService.Setup(x => x.GetFinancialByPolicyRef(It.IsAny<string>())).ReturnsAsync(returnData);
            var renewalController = new RenewalController(_logger.Object, mockPolicyDataService.Object, mockOnlineRenewalsProcessingDataService.Object);

            //Action
            var result = await renewalController.GetPolicyDetails("2");

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetPolicyDetails_ValidRequest_BadRequestObjectResult()
        {
            var mockOnlineRenewalsProcessingDataService = new Mock<IProcessingDataService>();

            var returnData = new AppErrorResult<FinancialResponseModel>(null, "Not found Financial detail");
            var mockPolicyDataService = new Mock<IPolicyService>();

            //Arrange
            mockPolicyDataService.Setup(x => x.GetFinancialByPolicyRef(It.IsAny<string>())).ReturnsAsync(returnData);
            var renewalController = new RenewalController(_logger.Object, mockPolicyDataService.Object, mockOnlineRenewalsProcessingDataService.Object);

            //Action
            var result = await renewalController.GetPolicyDetails(It.IsAny<string>());

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}