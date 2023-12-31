USE [Dev]
GO
/****** Object:  Table [dbo].[SystemCode]    Script Date: 7/19/2023 9:02:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemCode](
	[Code] [int] NOT NULL,
	[Key1] [varchar](20) NOT NULL,
	[CodeValue] [varchar](50) NULL,
	[CodeDescription] [varchar](100) NULL,
 CONSTRAINT [PK_SystemCode] PRIMARY KEY CLUSTERED 
(
	[Code] ASC,
	[Key1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
