USE [Gam3ia]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 09/05/2017 02:47:52 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CaseStudy]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaseStudy](
	[CaseID] [int] IDENTITY(1,1) NOT NULL,
	[VillageName] [nvarchar](150) NULL,
	[ReporterName] [nvarchar](150) NULL,
	[ReporterPhone] [nchar](15) NULL,
	[FamilyClass] [int] NULL,
	[PartnerName] [nvarchar](350) NULL,
	[PartnerNID] [nchar](15) NULL,
	[Address] [nvarchar](max) NULL,
	[Breadwinner] [int] NULL,
	[Job] [nvarchar](100) NULL,
	[EducationState] [int] NULL,
	[ChildrenNo] [int] NULL,
	[ChildrenInEducationNo] [int] NULL,
	[TravelledOrMarriedChildrenNo] [int] NULL,
	[Telephone1] [nchar](15) NULL,
	[Telephone2] [nchar](15) NULL,
	[Target] [nvarchar](max) NULL,
	[ReviewerOpinion] [nvarchar](max) NULL,
	[VolunteerID] [nvarchar](128) NULL,
	[WaterFees] [int] NULL,
	[ElectricityFees] [int] NULL,
	[InstallmentsFees] [int] NULL,
	[DrugsFees] [int] NULL,
	[RentFees] [int] NULL,
	[OtherFees] [int] NULL,
	[MonthlySalary] [int] NULL,
	[DailySalary] [int] NULL,
	[InsuranceIncome] [int] NULL,
	[SocitiesIncome] [int] NULL,
	[MaashIncome] [int] NULL,
	[OtherIncome] [int] NULL,
	[LandsOwned] [nvarchar](250) NULL,
	[AnimalsOwned] [nvarchar](250) NULL,
	[BirdsOwned] [nvarchar](250) NULL,
	[OtherOwned] [nvarchar](250) NULL,
	[DevicesOwned] [nvarchar](250) NULL,
	[RoomsNo] [int] NULL,
	[HouseType] [int] NULL CONSTRAINT [DF_CaseStudy_HouseType]  DEFAULT ((0)),
	[WallsType] [int] NULL,
	[RoofType] [int] NULL,
	[Floor] [nvarchar](150) NULL,
	[HasWaterLine] [bit] NULL,
	[HasElectLine] [bit] NULL,
	[HasSarfLine] [bit] NULL,
	[OtherLines] [nvarchar](250) NULL,
	[Comments] [nvarchar](max) NULL,
	[PoorID] [int] NULL,
	[ResearchDate] [datetime] NULL,
	[ReviewerName] [nvarchar](200) NULL,
	[IsDeserved] [bit] NULL,
 CONSTRAINT [PK_CaseStudy] PRIMARY KEY CLUSTERED 
(
	[CaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CaseStudy_Relative]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaseStudy_Relative](
	[CaseStudyID] [int] NOT NULL,
	[RelativeID] [int] NOT NULL,
 CONSTRAINT [PK_CaseStudy_Relative] PRIMARY KEY CLUSTERED 
(
	[CaseStudyID] ASC,
	[RelativeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[City]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](250) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Donation]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DonationValue] [int] NULL,
	[Date] [datetime] NULL,
	[VolunteerID] [nvarchar](128) NULL,
	[DonatorID] [int] NULL,
 CONSTRAINT [PK_Donation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Donator]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donator](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DonatorName] [nvarchar](max) NULL,
	[DonatorPhone] [nchar](50) NULL,
	[DonatorAddress] [nvarchar](max) NULL,
	[Email] [nvarchar](150) NULL,
	[Tag] [nvarchar](250) NULL,
	[Notes] [nvarchar](max) NULL,
	[Job] [nvarchar](150) NULL,
	[DonatorNID] [nvarchar](20) NULL,
	[JoinedAt] [datetime] NULL,
 CONSTRAINT [PK_Donator] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GaIncomeSource]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GaIncomeSource](
	[IncomeSourceID] [int] IDENTITY(1,1) NOT NULL,
	[IncomeSourceName] [nvarchar](250) NULL,
 CONSTRAINT [PK_GaIncomeSource] PRIMARY KEY CLUSTERED 
(
	[IncomeSourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GeneralAid]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralAid](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[PoorID] [int] NULL,
	[ServiceID] [int] NULL,
	[VolunteerID] [nvarchar](128) NULL,
	[ReceiveDate] [datetime] NULL,
	[Value] [int] NULL,
	[Tag] [nvarchar](max) NULL,
 CONSTRAINT [PK_GeneralAid] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GmIncome]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GmIncome](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IncomeSource] [int] NULL,
	[IncomeValue] [int] NULL,
	[EntryDate] [datetime] NULL,
	[VolunteerID] [nvarchar](128) NULL,
 CONSTRAINT [PK_GmIncome] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GmOutcome]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GmOutcome](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OutcomeSource] [int] NULL,
	[OutcomeValue] [int] NULL,
	[EntryDate] [datetime] NULL,
	[VolunteerID] [nvarchar](128) NULL,
 CONSTRAINT [PK_GmOutcome] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Loan]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Telephone1] [nvarchar](50) NULL,
	[Telephone2] [nvarchar](50) NULL,
	[Telephone3] [nvarchar](50) NULL,
	[Telephone4] [nvarchar](50) NULL,
	[WorkType] [int] NULL,
	[WorkAddress] [nvarchar](max) NULL,
	[WorkPhone] [nvarchar](50) NULL,
	[LoanValue] [int] NULL,
	[LoanReason] [nvarchar](max) NULL,
	[RequestDate] [datetime] NULL,
	[RequiredPapersSatisfied] [bit] NULL CONSTRAINT [DF_Loan_RequiredPapersSatisfied]  DEFAULT ((0)),
	[HasSalaryStatement] [bit] NULL,
	[MonthlyIncome] [int] NULL,
	[ReceiveDate] [datetime] NULL,
	[IsMonthlyPayment] [bit] NULL,
	[PaymentBehavior] [bit] NULL,
	[IrregularPaymentReason] [int] NULL,
	[GuarantorName] [nvarchar](250) NULL,
	[GuarantorAddress] [nvarchar](max) NULL,
	[GuarantorPhone1] [nchar](50) NULL,
	[GuarantorPhone2] [nchar](50) NULL,
	[GuarantorWorkType] [int] NULL,
	[GuarantorWorkAddress] [nvarchar](max) NULL,
	[GuarantorWorkPhone] [nchar](50) NULL,
	[GuarantorNID] [nchar](15) NULL,
	[GuarantorHasSalaryStatement] [bit] NULL,
	[VolunteerID] [nvarchar](128) NULL,
	[PoorID] [int] NULL,
	[HasCompleted] [bit] NULL,
	[HasJudged] [bit] NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Loan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoanInstallment]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanInstallment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DueDate] [datetime] NULL,
	[Amount] [int] NULL,
	[LoanID] [int] NULL,
	[Comments] [nvarchar](max) NULL,
	[PoorID] [int] NULL,
 CONSTRAINT [PK_LoanInstallment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OutcomeSource]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutcomeSource](
	[OutcomeSourceID] [int] NOT NULL,
	[OutcomeSourceName] [nvarchar](250) NULL,
 CONSTRAINT [PK_OutcomeSource] PRIMARY KEY CLUSTERED 
(
	[OutcomeSourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhysicalDonation]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhysicalDonation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DonationType] [nvarchar](100) NULL,
	[DeviceName] [nvarchar](150) NULL,
	[DeviceState] [nvarchar](100) NULL,
	[CanBeFixed] [bit] NULL,
	[FixFees] [int] NULL,
	[ReceiveDate] [datetime] NULL,
	[IsSelled] [bit] NULL,
	[IsDelivered] [bit] NULL,
	[SellPrice] [int] NULL,
	[SellDate] [datetime] NULL,
	[VolunteerID] [nvarchar](128) NULL,
	[DonatorID] [int] NULL,
	[PoorID] [int] NULL,
 CONSTRAINT [PK_PhysicalDonation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Poor]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PoorNID] [nchar](15) NULL,
	[PoorName] [nvarchar](350) NULL,
	[RegisterDate] [datetime] NULL,
	[CityID] [int] NULL,
 CONSTRAINT [PK_Poor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](250) NULL,
	[Quantity] [int] NULL,
	[TotalPrice] [int] NULL,
	[SellDate] [datetime] NULL,
	[VolunteerID] [nvarchar](128) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Relative]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relative](
	[ID] [int] NOT NULL,
	[RelativeName] [nvarchar](250) NULL,
	[RelativeNID] [nchar](15) NULL,
	[Relativity] [nvarchar](100) NULL,
	[BirthDate] [date] NULL,
	[EducationStage] [nvarchar](250) NULL,
	[EducationOrJob] [nvarchar](150) NULL,
	[HealthStatus] [nvarchar](150) NULL,
 CONSTRAINT [PK_Relative] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Service]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](150) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sponsor]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sponsor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SponsorName] [nvarchar](max) NULL,
	[SponsorPhone] [nchar](50) NULL,
	[SponsorAddress] [nvarchar](max) NULL,
	[Email] [nvarchar](150) NULL,
	[Notes] [nvarchar](max) NULL,
	[Job] [nvarchar](150) NULL,
	[SponsorNID] [nvarchar](20) NULL,
	[JoinedAt] [datetime] NULL,
 CONSTRAINT [PK_Sponsor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sponsorship]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sponsorship](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RequestCase] [int] NULL,
	[RequestReceiver] [nvarchar](250) NULL,
	[RequestFollowHolder] [nvarchar](250) NULL,
	[Amount] [int] NULL,
	[PaymentMethodType] [int] NULL,
	[WaseetName] [nvarchar](250) NULL,
	[WaseetPhone] [nchar](50) NULL,
	[SposorChanged] [bit] NULL,
	[OldSponsorName] [nvarchar](250) NULL,
	[NewSponsorName] [nvarchar](250) NULL,
	[ReasonOfChange] [nvarchar](max) NULL,
	[IsStopped] [bit] NULL,
	[StopDate] [datetime] NULL,
	[StopReason] [nvarchar](max) NULL,
	[VolunteerID] [nvarchar](128) NULL,
	[RefuseReason] [nvarchar](max) NULL,
	[IsRefused] [bit] NULL,
	[PoorID] [int] NULL,
	[SponsorID] [int] NULL,
	[RequestDate] [datetime] NULL,
	[Income] [int] NULL,
	[IncomeSource] [nvarchar](350) NULL,
 CONSTRAINT [PK_Sposorship] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SponsorshipInstallment]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SponsorshipInstallment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DueDate] [datetime] NULL,
	[Amount] [nchar](10) NULL,
	[IsCalled] [bit] NULL,
	[CallerName] [nvarchar](250) NULL,
	[CallDate] [datetime] NULL,
	[IsDeliverdToPoor] [bit] NULL,
	[DeliveryDate] [datetime] NULL,
	[SposorshipID] [int] NULL,
	[January] [bit] NULL,
	[February] [bit] NULL,
	[March] [bit] NULL,
	[April] [bit] NULL,
	[May] [bit] NULL,
	[June] [bit] NULL,
	[July] [bit] NULL,
	[August] [bit] NULL,
	[September] [bit] NULL,
	[October] [bit] NULL,
	[November] [bit] NULL,
	[December] [bit] NULL,
	[Year] [nvarchar](50) NULL,
	[SponsorID] [int] NULL,
 CONSTRAINT [PK_SponsorshipInstallment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SponsorshipResearch]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SponsorshipResearch](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ResearcherName] [nvarchar](250) NULL,
	[ResearchDate] [datetime] NULL,
	[ResearchResponse] [nvarchar](max) NULL,
	[ResearchResults] [nvarchar](max) NULL,
	[SponsorshipStartDate] [datetime] NULL,
	[Comments] [nvarchar](max) NULL,
	[VolunteerID] [nvarchar](128) NULL,
	[PoorID] [int] NULL,
 CONSTRAINT [PK_SposorshipResearch] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentAid]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAid](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudyYear] [nvarchar](50) NULL,
	[SchoolName] [nvarchar](250) NULL,
	[RequiredFeesValue] [int] NULL,
	[RequiredFeesType] [int] NULL,
	[OtherFeesValue] [int] NULL,
	[OtherFeesType] [int] NULL,
	[VolunteerID] [nvarchar](128) NULL,
	[PoorID] [int] NULL,
	[SchoolAddress] [nvarchar](250) NULL,
	[Notes] [nvarchar](max) NULL,
	[StudentName] [nvarchar](350) NULL,
 CONSTRAINT [PK_StudentAid] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Volunteer]    Script Date: 09/05/2017 02:47:53 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Volunteer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VolunteerName] [nvarchar](max) NULL,
	[Job] [nvarchar](250) NULL,
	[Email] [nchar](250) NULL,
	[Notes] [nvarchar](max) NULL,
	[Telephone] [nvarchar](200) NULL,
 CONSTRAINT [PK_Volunteer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CaseStudy]  WITH CHECK ADD  CONSTRAINT [FK_CaseStudy_AspNetUsers] FOREIGN KEY([VolunteerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[CaseStudy] CHECK CONSTRAINT [FK_CaseStudy_AspNetUsers]
GO
ALTER TABLE [dbo].[CaseStudy]  WITH CHECK ADD  CONSTRAINT [FK_CaseStudy_Poor] FOREIGN KEY([PoorID])
REFERENCES [dbo].[Poor] ([ID])
GO
ALTER TABLE [dbo].[CaseStudy] CHECK CONSTRAINT [FK_CaseStudy_Poor]
GO
ALTER TABLE [dbo].[CaseStudy_Relative]  WITH CHECK ADD  CONSTRAINT [FK_CaseStudy_Relative_Relative] FOREIGN KEY([RelativeID])
REFERENCES [dbo].[Relative] ([ID])
GO
ALTER TABLE [dbo].[CaseStudy_Relative] CHECK CONSTRAINT [FK_CaseStudy_Relative_Relative]
GO
ALTER TABLE [dbo].[Donation]  WITH CHECK ADD  CONSTRAINT [FK_Donation_AspNetUsers] FOREIGN KEY([VolunteerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Donation] CHECK CONSTRAINT [FK_Donation_AspNetUsers]
GO
ALTER TABLE [dbo].[Donation]  WITH CHECK ADD  CONSTRAINT [FK_Donation_Donator] FOREIGN KEY([DonatorID])
REFERENCES [dbo].[Donator] ([ID])
GO
ALTER TABLE [dbo].[Donation] CHECK CONSTRAINT [FK_Donation_Donator]
GO
ALTER TABLE [dbo].[GeneralAid]  WITH CHECK ADD  CONSTRAINT [FK_GeneralAid_AspNetUsers] FOREIGN KEY([VolunteerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[GeneralAid] CHECK CONSTRAINT [FK_GeneralAid_AspNetUsers]
GO
ALTER TABLE [dbo].[GeneralAid]  WITH CHECK ADD  CONSTRAINT [FK_GeneralAid_Poor] FOREIGN KEY([PoorID])
REFERENCES [dbo].[Poor] ([ID])
GO
ALTER TABLE [dbo].[GeneralAid] CHECK CONSTRAINT [FK_GeneralAid_Poor]
GO
ALTER TABLE [dbo].[GeneralAid]  WITH CHECK ADD  CONSTRAINT [FK_GeneralAid_Service] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ServiceID])
GO
ALTER TABLE [dbo].[GeneralAid] CHECK CONSTRAINT [FK_GeneralAid_Service]
GO
ALTER TABLE [dbo].[GmIncome]  WITH CHECK ADD  CONSTRAINT [FK_GmIncome_AspNetUsers] FOREIGN KEY([VolunteerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[GmIncome] CHECK CONSTRAINT [FK_GmIncome_AspNetUsers]
GO
ALTER TABLE [dbo].[GmOutcome]  WITH CHECK ADD  CONSTRAINT [FK_GmOutcome_AspNetUsers] FOREIGN KEY([VolunteerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[GmOutcome] CHECK CONSTRAINT [FK_GmOutcome_AspNetUsers]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_AspNetUsers] FOREIGN KEY([VolunteerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK_Loan_AspNetUsers]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_Poor] FOREIGN KEY([PoorID])
REFERENCES [dbo].[Poor] ([ID])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK_Loan_Poor]
GO
ALTER TABLE [dbo].[LoanInstallment]  WITH CHECK ADD  CONSTRAINT [FK_LoanInstallment_Loan] FOREIGN KEY([LoanID])
REFERENCES [dbo].[Loan] ([ID])
GO
ALTER TABLE [dbo].[LoanInstallment] CHECK CONSTRAINT [FK_LoanInstallment_Loan]
GO
ALTER TABLE [dbo].[LoanInstallment]  WITH CHECK ADD  CONSTRAINT [FK_LoanInstallment_Poor] FOREIGN KEY([PoorID])
REFERENCES [dbo].[Poor] ([ID])
GO
ALTER TABLE [dbo].[LoanInstallment] CHECK CONSTRAINT [FK_LoanInstallment_Poor]
GO
ALTER TABLE [dbo].[PhysicalDonation]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalDonation_AspNetUsers] FOREIGN KEY([VolunteerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[PhysicalDonation] CHECK CONSTRAINT [FK_PhysicalDonation_AspNetUsers]
GO
ALTER TABLE [dbo].[PhysicalDonation]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalDonation_Donator] FOREIGN KEY([DonatorID])
REFERENCES [dbo].[Donator] ([ID])
GO
ALTER TABLE [dbo].[PhysicalDonation] CHECK CONSTRAINT [FK_PhysicalDonation_Donator]
GO
ALTER TABLE [dbo].[PhysicalDonation]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalDonation_Poor] FOREIGN KEY([PoorID])
REFERENCES [dbo].[Poor] ([ID])
GO
ALTER TABLE [dbo].[PhysicalDonation] CHECK CONSTRAINT [FK_PhysicalDonation_Poor]
GO
ALTER TABLE [dbo].[Poor]  WITH CHECK ADD  CONSTRAINT [FK_Poor_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[Poor] CHECK CONSTRAINT [FK_Poor_City]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_AspNetUsers] FOREIGN KEY([VolunteerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_AspNetUsers]
GO
ALTER TABLE [dbo].[Sponsorship]  WITH CHECK ADD  CONSTRAINT [FK_Sponsorship_Sponsor] FOREIGN KEY([SponsorID])
REFERENCES [dbo].[Sponsor] ([ID])
GO
ALTER TABLE [dbo].[Sponsorship] CHECK CONSTRAINT [FK_Sponsorship_Sponsor]
GO
ALTER TABLE [dbo].[Sponsorship]  WITH CHECK ADD  CONSTRAINT [FK_Sponsorship1_Poor] FOREIGN KEY([PoorID])
REFERENCES [dbo].[Poor] ([ID])
GO
ALTER TABLE [dbo].[Sponsorship] CHECK CONSTRAINT [FK_Sponsorship1_Poor]
GO
ALTER TABLE [dbo].[Sponsorship]  WITH CHECK ADD  CONSTRAINT [FK_Sposorship_AspNetUsers] FOREIGN KEY([VolunteerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Sponsorship] CHECK CONSTRAINT [FK_Sposorship_AspNetUsers]
GO
ALTER TABLE [dbo].[SponsorshipInstallment]  WITH CHECK ADD  CONSTRAINT [FK_SponsorshipInstallment_Sponsor] FOREIGN KEY([SponsorID])
REFERENCES [dbo].[Sponsor] ([ID])
GO
ALTER TABLE [dbo].[SponsorshipInstallment] CHECK CONSTRAINT [FK_SponsorshipInstallment_Sponsor]
GO
ALTER TABLE [dbo].[SponsorshipInstallment]  WITH CHECK ADD  CONSTRAINT [FK_SponsorshipInstallment_Sposorship] FOREIGN KEY([SposorshipID])
REFERENCES [dbo].[Sponsorship] ([ID])
GO
ALTER TABLE [dbo].[SponsorshipInstallment] CHECK CONSTRAINT [FK_SponsorshipInstallment_Sposorship]
GO
ALTER TABLE [dbo].[SponsorshipResearch]  WITH CHECK ADD  CONSTRAINT [FK_SponsorshipResearch_Poor] FOREIGN KEY([PoorID])
REFERENCES [dbo].[Poor] ([ID])
GO
ALTER TABLE [dbo].[SponsorshipResearch] CHECK CONSTRAINT [FK_SponsorshipResearch_Poor]
GO
ALTER TABLE [dbo].[SponsorshipResearch]  WITH CHECK ADD  CONSTRAINT [FK_SposorshipResearch_AspNetUsers] FOREIGN KEY([VolunteerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[SponsorshipResearch] CHECK CONSTRAINT [FK_SposorshipResearch_AspNetUsers]
GO
ALTER TABLE [dbo].[StudentAid]  WITH CHECK ADD  CONSTRAINT [FK_StudentAid_AspNetUsers] FOREIGN KEY([VolunteerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[StudentAid] CHECK CONSTRAINT [FK_StudentAid_AspNetUsers]
GO
ALTER TABLE [dbo].[StudentAid]  WITH CHECK ADD  CONSTRAINT [FK_StudentAid_Poor] FOREIGN KEY([PoorID])
REFERENCES [dbo].[Poor] ([ID])
GO
ALTER TABLE [dbo].[StudentAid] CHECK CONSTRAINT [FK_StudentAid_Poor]
GO
