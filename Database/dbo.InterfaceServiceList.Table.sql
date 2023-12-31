USE [Dev]
GO
/****** Object:  Table [dbo].[InterfaceServiceList]    Script Date: 7/19/2023 9:02:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterfaceServiceList](
	[InterfaceServiceID] [int] NOT NULL,
	[InterfaceServiceName] [varchar](100) NOT NULL,
	[InterfaceServiceDescription] [varchar](250) NULL,
	[InterfaceServiceURL] [varchar](500) NOT NULL,
 CONSTRAINT [PK_InterfaceServiceList] PRIMARY KEY CLUSTERED 
(
	[InterfaceServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[InterfaceServiceList] ([InterfaceServiceID], [InterfaceServiceName], [InterfaceServiceDescription], [InterfaceServiceURL]) VALUES (1, N'AddCode', N'Add new System Code', N'https://localhost/api/')
INSERT [dbo].[InterfaceServiceList] ([InterfaceServiceID], [InterfaceServiceName], [InterfaceServiceDescription], [InterfaceServiceURL]) VALUES (2, N'EditCode', N'Edit System Code', N'https://localhost/api/')
GO
