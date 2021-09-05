using Renewal.Application.Models.ProcessingData;
using Renewal.Application.Validator.ProcessingData;
using Xunit;

namespace Renewal.Application.UnitTests.Validator
{
    public class UpdatePaymentMethodRequestModelValidatorTest
    {
        private readonly UpdatePaymentMethodRequestModel _model;
        private readonly UpdatePaymentMethodRequestModelValidator _validator;

        public UpdatePaymentMethodRequestModelValidatorTest()
        {
            _model = new UpdatePaymentMethodRequestModel
            {
                PolicyReference = "PolicyReferenceNumber",
                PaymentMethod = "PaymentMethod"
            };

            _validator = new UpdatePaymentMethodRequestModelValidator();
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
        public void ShouldFail_When_PaymentMethod_Is_Empty(string paymentMethod)
        {
            _model.PaymentMethod = paymentMethod;
            var result = _validator.Validate(_model);
            Assert.False(result.IsValid);
        }
    }
}
