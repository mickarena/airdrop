CREATE TABLE [dbo].[RenewalInvites] (
    [PolicyReference]     VARCHAR (50)  NOT NULL,
    [Forename]            VARCHAR (50)  NOT NULL,
    [Surname]             VARCHAR (50)  NOT NULL,
    [DateofBirth]         DATE          NOT NULL,
    [AddressLine1]        VARCHAR (50)  NOT NULL,
    [AddressLine2]        VARCHAR (50)  NOT NULL,
    [AddressLine3]        VARCHAR (50)  NULL,
    [AddressLine4]        VARCHAR (50)  NULL,
    [Email]               VARCHAR (320) NULL,
    [PostCode]            VARCHAR (9)   NOT NULL,
    [PolicyLine]          SMALLINT      NOT NULL,
    [PolicyType]          VARCHAR (2)   NOT NULL,
    [TotalPremiumPIF]     INT           NOT NULL,
    [NumberInstalments]   TINYINT       NOT NULL,
    [MonthlyPayment]      INT           NOT NULL,
    [Deposit]             INT           NOT NULL,
    [FinanceCharge]       INT           NOT NULL,
    [TotalPremiumDD]      INT           NOT NULL,
    [APR]                 INT           NOT NULL,
    [InterestRate]        INT           NOT NULL,
    [CompanyCode]         VARCHAR (2)   NULL,
    [RenewalDate]         DATE          NOT NULL,
    [VehicleRegistration] VARCHAR (10)  NULL,
    [PolicyStatus]        VARCHAR (2)   NULL,
    [AffinityCode]        VARCHAR (4)   NULL,
    [BrandCode]           VARCHAR (2)   NULL,
    [DateCreated]         DATETIME      NULL,
    [BookOnLine]          TINYINT       NULL,
    [RenewalLetterRef]    VARCHAR (50)  NOT NULL,
    [Prefix]              VARCHAR (8)   NULL,
    CONSTRAINT [PK_RenewalInvites] PRIMARY KEY CLUSTERED ([PolicyReference] ASC)
);
















