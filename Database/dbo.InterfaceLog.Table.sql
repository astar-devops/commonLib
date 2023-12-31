USE [Dev]
GO
/****** Object:  Table [dbo].[InterfaceLog]    Script Date: 8/10/2023 3:38:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterfaceLog](
	[InterfaceLogID] [int] IDENTITY(1,1) NOT NULL,
	[RequestID] [varchar](50) NOT NULL,
	[InterfaceTypeID] [int] NOT NULL,
	[InterfaceServiceID] [int] NOT NULL,
	[RequestPayload] [nvarchar](max) NULL,
	[ResponsePayload] [nvarchar](max) NULL,
	[RequestDateTime] [datetime] NULL,
	[ResponseDateTime] [datetime] NULL,
	[ProcessFlag] [char](1) NULL,
	[RetryCount] [int] NULL,
	[StatusCode] [varchar](10) NULL,
	[ErrorDateTime] [datetime] NULL,
	[ErrorDescription] [varchar](max) NULL,
	[RefID] [varchar](50) NULL,
 CONSTRAINT [PK_InterfaceLog] PRIMARY KEY CLUSTERED 
(
	[InterfaceLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[InterfaceLog] ON 

INSERT [dbo].[InterfaceLog] ([InterfaceLogID], [RequestID], [InterfaceTypeID], [InterfaceServiceID], [RequestPayload], [ResponsePayload], [RequestDateTime], [ResponseDateTime], [ProcessFlag], [RetryCount], [StatusCode], [ErrorDateTime], [ErrorDescription], [RefID]) VALUES (1, N'SYSA202308101439461475', 1, 1, N'{
  "Code": 1,
  "Key1": "A",
  "CodeValue": "test value",
  "CodeDescription": "test desc"
}', N'{
  "IsSuccess": true,
  "RequestID": "SYSA202308101439461475"
}', CAST(N'2023-08-10T14:39:46.673' AS DateTime), CAST(N'2023-08-10T14:39:47.843' AS DateTime), N'S', NULL, N'200', NULL, NULL, NULL)
INSERT [dbo].[InterfaceLog] ([InterfaceLogID], [RequestID], [InterfaceTypeID], [InterfaceServiceID], [RequestPayload], [ResponsePayload], [RequestDateTime], [ResponseDateTime], [ProcessFlag], [RetryCount], [StatusCode], [ErrorDateTime], [ErrorDescription], [RefID]) VALUES (2, N'SYSA202308101441562918', 1, 1, N'{
  "Code": 1,
  "Key1": "A",
  "CodeValue": "test value",
  "CodeDescription": "test desc"
}', N'{
  "IsSuccess": false,
  "RequestID": null
}', CAST(N'2023-08-10T14:41:56.513' AS DateTime), CAST(N'2023-08-10T14:41:56.660' AS DateTime), N'E', NULL, N'400', CAST(N'2023-08-10T14:41:56.660' AS DateTime), N'An error occurred while saving the entity changes. See the inner exception for details.', NULL)
SET IDENTITY_INSERT [dbo].[InterfaceLog] OFF
GO
ALTER TABLE [dbo].[InterfaceLog]  WITH CHECK ADD  CONSTRAINT [FK_InterfaceLog_InterfaceServiceList] FOREIGN KEY([InterfaceServiceID])
REFERENCES [dbo].[InterfaceServiceList] ([InterfaceServiceID])
GO
ALTER TABLE [dbo].[InterfaceLog] CHECK CONSTRAINT [FK_InterfaceLog_InterfaceServiceList]
GO
ALTER TABLE [dbo].[InterfaceLog]  WITH CHECK ADD  CONSTRAINT [FK_InterfaceLog_InterfaceTypeList] FOREIGN KEY([InterfaceTypeID])
REFERENCES [dbo].[InterfaceTypeList] ([InterfaceTypeID])
GO
ALTER TABLE [dbo].[InterfaceLog] CHECK CONSTRAINT [FK_InterfaceLog_InterfaceTypeList]
GO
