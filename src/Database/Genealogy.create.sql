CREATE TABLE [dbo].[Obituaries] (
	[OB_ID] [int] NOT NULL,
	[First_Name] [varchar](50) NOT NULL,
	[Last_Name] [varchar](50) NOT NULL,
	[Alt_Name] [varchar](50) NULL,
	[Date_Of_Record] [datetime] NOT NULL,
	[Birth_Date] [varchar](10) NULL,
	[Age] [int] NULL,
	[Web_Text] [varchar](8000) NULL,
	[COUNTY_ID] [int] NOT NULL,
	[NEWS_ID] [int] NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Naturalization] (
	[NAT_ID] [int] NOT NULL,
	[First_Name] [varchar] (50) NOT NULL ,
	[Last_Name] [varchar] (50) NOT NULL ,
	[DOB] [varchar] (10) NULL ,
	[AGE] [int] NULL,
	[Date_Filed] [datetime] NOT NULL,
	[Record_Type] [varchar] (50) NOT NULL,
	[Country_of_Origin] [varchar] (50) NOT NULL,
	[Series] [int] NOT NULL,
	[Box] [int] NOT NULL,
	[Folder] [int] NOT NULL,
	[Vol_Number] [varchar] (10) NOT NULL,
	[Page_Cert_Num] [varchar] (50) NOT NULL,
	[Date_of_Entry] [varchar] (50) NOT NULL,
	[Port_of_Entry] [varchar] (50) NOT NULL,
	[COUNTY_ID] [int] NOT NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Census] (
	[CEN_ID] [int] NOT NULL,
	[First_Name] [varchar](50) NOT NULL,
	[Last_Name] [varchar](50) NOT NULL,
	[AGE] [int] NOT NULL,
	[Date_Of_Record] [datetime] NOT NULL,
	[Page] [varchar](5) NOT NULL,
	[Town] [varchar](50) NOT NULL,
	[COUNTY_ID] [int] NOT NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Census_Member] (
	[CM_ID] [int] NOT NULL,
	[FIRST_NAME] [VARCHAR] (50) NOT NULL,
	[LAST_NAME] [VARCHAR] (50) NOT NULL,
	[AGE] [INT] NOT NULL,
	[PAGE] [VARCHAR] (5),
	[CEN_ID] [int] NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Newspapers] (
	[NEWS_ID] [int] NOT NULL,
	[Full] [varchar](50) NOT NULL,
	[Abbr] [varchar](10) NOT NULL,
	[URL] [varchar](200) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[County] (
	[COUNTY_ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Charge_Amounts] (
	[CHARGE_ID] [int] NOT NULL,
	[First_Range] [int] NULL,
	[Second_Range] [int] NULL,
	[First_O_Price] [money] NOT NULL,
	[Second_O_Price] [money] NOT NULL,
	[Last_O_Price] [money] NOT NULL,
	[First_C_Price] [money] NOT NULL,
	[Second_C_Price] [money] NOT NULL,
	[Last_C_Price] [money] NOT NULL,
	[First_N_Price] [money] NOT NULL,
	[Second_N_Price] [money] NOT NULL,
	[Last_N_Price] [money] NOT NULL
) ON [PRIMARY]
GO

--Next sprint need to contact person in charge of third party software for charging money
--CREATE TABLE [dbo].[Orders] (
--	
--) ON [PRIMARY]
--GO

CREATE TABLE [dbo].[Customer] (
	[Cust_ID] [int] NOT NULL,
	[First_Name] [varchar](50) NOT NULL,
	[Last_Name] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Address_2] [varchar](50) NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NULL,
	[Zip] [varchar](10) NULL,
	[Country] [varchar](50) NOT NULL,
	[Province] [varchar](50) NULL,
	[Postal_Code] [varchar](50) NULL,
	[Email] [varchar](200) NOT NULL,
) ON [PRIMARY]
GO



--Adds keys to tables
ALTER TABLE [dbo].[Obituaries] WITH NOCHECK ADD
	CONSTRAINT [PK_Obituaries] PRIMARY KEY CLUSTERED
 	(
		[OB_ID]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Naturalization] WITH NOCHECK ADD
	CONSTRAINT [PK_Naturalization] PRIMARY KEY CLUSTERED
 (
		[NAT_ID]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Census] WITH NOCHECK ADD
	CONSTRAINT [PK_Census] PRIMARY KEY CLUSTERED
 	(
		[CEN_ID]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Census_Member] WITH NOCHECK ADD
	CONSTRAINT [PK_Census_Member] PRIMARY KEY CLUSTERED
 	(
		[CM_ID]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Newspapers] WITH NOCHECK ADD
	CONSTRAINT [PK_Newspapers] PRIMARY KEY CLUSTERED
 	(
		[NEWS_ID]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[County] WITH NOCHECK ADD
	CONSTRAINT [PK_County] PRIMARY KEY CLUSTERED
 	(
		[COUNTY_ID]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customer] WITH NOCHECK ADD
	CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED
 	(
		[CUST_ID]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Charge_Amounts] WITH NOCHECK ADD
	CONSTRAINT [PK_Charge_Amounts] PRIMARY KEY CLUSTERED
 	(
		[CHARGE_ID]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Obituaries] ADD
	CONSTRAINT [FK_Obituaries_County] FOREIGN KEY 
 	(
		[COUNTY_ID]
) REFERENCES [dbo].[County] (
	[COUNTY_ID]
),
CONSTRAINT [FK_Obituaries_Newspapers] FOREIGN KEY
(
	[NEWS_ID]
) REFERENCES [dbo].[Newspapers] (
	[NEWS_ID]
)
GO

ALTER TABLE [dbo].[Naturalization] ADD
	CONSTRAINT [FK_Naturalization_County] FOREIGN KEY 
 	(
		[COUNTY_ID]
) REFERENCES [dbo].[County] (
	[COUNTY_ID]
)
GO

ALTER TABLE [dbo].[Census] ADD
	CONSTRAINT [FK_Census_County] FOREIGN KEY 
 	(
		[COUNTY_ID]
) REFERENCES [dbo].[County] (
	[COUNTY_ID]
)
GO

ALTER TABLE [dbo].[Census_Member] ADD
	CONSTRAINT [FK_Census_Member_Census] FOREIGN KEY 
 	(
		[CEN_ID]
) REFERENCES [dbo].[Census] (
	[CEN_ID]
)
GO
