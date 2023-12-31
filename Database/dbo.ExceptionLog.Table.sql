USE [Dev]
GO
/****** Object:  Table [dbo].[ExceptionLog]    Script Date: 8/10/2023 3:38:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExceptionLog](
	[ExceptionLogID] [int] IDENTITY(1,1) NOT NULL,
	[ExceptionTypeID] [int] NOT NULL,
	[ExceptionDateTime] [datetime] NOT NULL,
	[ExceptionDescription] [varchar](max) NOT NULL,
	[RefID] [varchar](50) NULL,
 CONSTRAINT [PK_ExceptionLog] PRIMARY KEY CLUSTERED 
(
	[ExceptionLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ExceptionLog] ON 

INSERT [dbo].[ExceptionLog] ([ExceptionLogID], [ExceptionTypeID], [ExceptionDateTime], [ExceptionDescription], [RefID]) VALUES (1, 3, CAST(N'2023-08-10T14:41:56.673' AS DateTime), N'An error occurred while saving the entity changes. See the inner exception for details.', N'SYSA202308101441562918')
SET IDENTITY_INSERT [dbo].[ExceptionLog] OFF
GO
ALTER TABLE [dbo].[ExceptionLog]  WITH CHECK ADD  CONSTRAINT [FK_ExceptionLog_ExceptionTypeList] FOREIGN KEY([ExceptionTypeID])
REFERENCES [dbo].[ExceptionTypeList] ([ExceptionTypeID])
GO
ALTER TABLE [dbo].[ExceptionLog] CHECK CONSTRAINT [FK_ExceptionLog_ExceptionTypeList]
GO
