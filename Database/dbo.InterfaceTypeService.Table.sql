USE [Dev]
GO
/****** Object:  Table [dbo].[InterfaceTypeService]    Script Date: 7/19/2023 9:02:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterfaceTypeService](
	[InterfaceTypeID] [int] NOT NULL,
	[InterfaceServiceID] [int] NOT NULL,
 CONSTRAINT [PK_InterfaceTypeService] PRIMARY KEY CLUSTERED 
(
	[InterfaceTypeID] ASC,
	[InterfaceServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[InterfaceTypeService] ([InterfaceTypeID], [InterfaceServiceID]) VALUES (1, 1)
INSERT [dbo].[InterfaceTypeService] ([InterfaceTypeID], [InterfaceServiceID]) VALUES (1, 2)
GO
ALTER TABLE [dbo].[InterfaceTypeService]  WITH CHECK ADD  CONSTRAINT [FK_InterfaceTypeService_InterfaceServiceList] FOREIGN KEY([InterfaceServiceID])
REFERENCES [dbo].[InterfaceServiceList] ([InterfaceServiceID])
GO
ALTER TABLE [dbo].[InterfaceTypeService] CHECK CONSTRAINT [FK_InterfaceTypeService_InterfaceServiceList]
GO
ALTER TABLE [dbo].[InterfaceTypeService]  WITH CHECK ADD  CONSTRAINT [FK_InterfaceTypeService_InterfaceTypeList] FOREIGN KEY([InterfaceTypeID])
REFERENCES [dbo].[InterfaceTypeList] ([InterfaceTypeID])
GO
ALTER TABLE [dbo].[InterfaceTypeService] CHECK CONSTRAINT [FK_InterfaceTypeService_InterfaceTypeList]
GO
