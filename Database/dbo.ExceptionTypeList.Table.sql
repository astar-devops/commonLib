USE [Dev]
GO
/****** Object:  Table [dbo].[ExceptionTypeList]    Script Date: 7/19/2023 9:02:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExceptionTypeList](
	[ExceptionTypeID] [int] NOT NULL,
	[ExceptionTypeName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ExceptionTypeList] PRIMARY KEY CLUSTERED 
(
	[ExceptionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ExceptionTypeList] ([ExceptionTypeID], [ExceptionTypeName]) VALUES (1, N'Mobile')
INSERT [dbo].[ExceptionTypeList] ([ExceptionTypeID], [ExceptionTypeName]) VALUES (2, N'Web Portal')
INSERT [dbo].[ExceptionTypeList] ([ExceptionTypeID], [ExceptionTypeName]) VALUES (3, N'API Interface 1')
INSERT [dbo].[ExceptionTypeList] ([ExceptionTypeID], [ExceptionTypeName]) VALUES (4, N'API Interface 2')
GO
