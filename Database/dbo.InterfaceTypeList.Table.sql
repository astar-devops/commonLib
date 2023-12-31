USE [Dev]
GO
/****** Object:  Table [dbo].[InterfaceTypeList]    Script Date: 7/19/2023 9:02:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterfaceTypeList](
	[InterfaceTypeID] [int] NOT NULL,
	[InterfaceTypeName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_InterfaceTypeList] PRIMARY KEY CLUSTERED 
(
	[InterfaceTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[InterfaceTypeList] ([InterfaceTypeID], [InterfaceTypeName]) VALUES (1, N'Interface A')
INSERT [dbo].[InterfaceTypeList] ([InterfaceTypeID], [InterfaceTypeName]) VALUES (2, N'Interface B')
GO
