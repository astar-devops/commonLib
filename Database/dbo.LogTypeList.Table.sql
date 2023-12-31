USE [Dev]
GO
/****** Object:  Table [dbo].[LogTypeList]    Script Date: 7/19/2023 9:02:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTypeList](
	[LogTypeID] [int] NOT NULL,
	[LogTypeName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_LogTypeList] PRIMARY KEY CLUSTERED 
(
	[LogTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[LogTypeList] ([LogTypeID], [LogTypeName]) VALUES (1, N'Mobile Login/Logout')
INSERT [dbo].[LogTypeList] ([LogTypeID], [LogTypeName]) VALUES (2, N'Web Login/Logout')
INSERT [dbo].[LogTypeList] ([LogTypeID], [LogTypeName]) VALUES (3, N'Code Management')
INSERT [dbo].[LogTypeList] ([LogTypeID], [LogTypeName]) VALUES (4, N'Document Management')
INSERT [dbo].[LogTypeList] ([LogTypeID], [LogTypeName]) VALUES (5, N'Inventory Management')
GO
