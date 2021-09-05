CREATE TABLE [dbo].[RenewalProcessing] (
    [Id]                               UNIQUEIDENTIFIER NOT NULL,
    [PolicyReference]                  VARCHAR (50)     NOT NULL,
    [PaymentMethod]                    VARCHAR (12)     NULL,
    [Deposit]                          INT              NOT NULL,
    [TotalPremiumPIF]                  INT              NOT NULL,
    [NumberInstalments]                TINYINT          NOT NULL,
    [MonthlyPayment]                   INT              NOT NULL,
    [FinanceCharge]                    INT              NOT NULL,
    [TotalPremiumDD]                   INT              NOT NULL,
    [APR]                              INT              NOT NULL,
    [InterestRate]                     INT              NOT NULL,
    [PaymentTransactionId]             VARCHAR (50)     NULL,
    [PolicyLine]                       SMALLINT         NOT NULL,
    [PolicyStatus]                     VARCHAR (2)      NULL,
    [RenewalProcessStatus]             INT              NULL,
    [RenewalProcessStatusDate]         DATETIME         NULL,
    [Forename]                         VARCHAR (50)     NOT NULL,
    [Surname]                          VARCHAR (50)     NOT NULL,
    [DateOfBirth]                      DATETIME         NOT NULL,
    [AddressLine1]                     VARCHAR (50)     NOT NULL,
    [AddressLine2]                     VARCHAR (50)     NOT NULL,
    [AddressLine3]                     VARCHAR (50)     NULL,
    [AddressLine4]                     VARCHAR (50)     NULL,
    [PostCode]                         VARCHAR (9)      NOT NULL,
    [Email]                            VARCHAR (320)    NULL,
    [VehicleRegistration]              VARCHAR (10)     NULL,
    [EncryptedAccountHolder]           VARCHAR (MAX)    NULL,
    [EncryptedBankAccountNumber]       VARCHAR (MAX)    NULL,
    [EncryptedBankSortCode]            VARCHAR (MAX)    NULL,
    [BankName]                         VARCHAR (MAX)    NULL,
    [PolicyType]                       VARCHAR (2)      NOT NULL,
    [AffinityCode]                     VARCHAR (4)      NULL,
    [RenewalDate]                      DATE             NULL,
    [EmailDocuments]                   BIT              NULL,
    [StatementofFactConfirmed]         BIT              NULL,
    [CPAAuthorisation]                 BIT              NULL,
    [DirectDebitReadConfirmation]      BIT              NULL,
    [DirectDebitRepaymentConfirmation] BIT              NULL,
    [CompanyCode]                      VARCHAR (2)      NULL,
    [BrandCode]                        VARCHAR (2)      NULL,
    [DateCreated]                      DATETIME         NULL,
    [BookOnLine]                       TINYINT          NULL,
    [PaymentDateCreated]               DATETIME         NULL,
    [TotalPayment]                     INT              NULL,
    [RenewalLetterRef]                 VARCHAR (50)     NOT NULL,
    [Prefix]                           VARCHAR (8)      NULL,
    [DataTransferDate]                 DATETIME         NULL,
    CONSTRAINT [PK_RenewalProcessing] PRIMARY KEY CLUSTERED ([Id] ASC)
);






















