using Renewal.Application.Models.ProcessingData;
using Renewal.Application.Validator.ProcessingData;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Renewal.Application.UnitTests.Validator
{
    public class UpdateBankAccountRequestModelValidatorTest
    {
        private readonly UpdateBankAccountRequestModel _model;
        private readonly UpdateBankAccountRequestModelValidator _validator;

        public UpdateBankAccountRequestModelValidatorTest()
        {
            _model = new UpdateBankAccountRequestModel
            {
                PolicyReference = "PolicyReferenceNumber",
                EncryptedBankAccountNumber = "EncBankAccountNumber",
                EncryptedAccountHolder = "EncBankAccountName",
                EncryptedBankSortCode = "EncSortCode"
            };

            _validator = new UpdateBankAccountRequestModelValidator();
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
        public void Success_When_PolicyReferenceNumber_Is_Empty(string policyReferenceNumber)
        {
            _model.EncryptedBankAccountNumber = policyReferenceNumber;
            var result = _validator.Validate(_model);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Success_When_EncBankAccountName_Is_Empty(string encBankAccountName)
        {
            _model.EncryptedAccountHolder = encBankAccountName;
            var result = _validator.Validate(_model);
            Assert.True(result.IsValid);
        }
    }
}
