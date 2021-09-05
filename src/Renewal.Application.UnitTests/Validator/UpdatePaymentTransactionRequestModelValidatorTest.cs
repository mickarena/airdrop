using Renewal.Application.Models.ProcessingData;
using Renewal.Application.Validator.ProcessingData;
using System;
using Xunit;

namespace Renewal.Application.UnitTests.Validator
{
    public class UpdatePaymentTransactionRequestModelValidatorTest
    {
        private readonly UpdatePaymentTransactionRequestModel _model;
        private readonly UpdatePaymentTransactionRequestModelValidator _validator;

        public UpdatePaymentTransactionRequestModelValidatorTest()
        {
            _model = new UpdatePaymentTransactionRequestModel
            {
                PolicyReference = "PolicyReferenceNumber",
                RenewalProcessStatus = "Status",
                RenewalProcessStatusDate = DateTime.Now
            };

            _validator = new UpdatePaymentTransactionRequestModelValidator();
        }

        [Fact]
        public void ShouldSuccess_When_Model_Is_Valid()
        {
            var result = _validator.Validate(_model);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFail_When_PolicyReferenceNumber_Is_Empty(string policyReferenceNumber)
        {
            _model.PolicyReference = policyReferenceNumber;
            var result = _validator.Validate(_model);
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFail_When_Status_Is_Empty(string status)
        {
            _model.RenewalProcessStatus = status;
            var result = _validator.Validate(_model);
            Assert.False(result.IsValid);
        }
    }
}
