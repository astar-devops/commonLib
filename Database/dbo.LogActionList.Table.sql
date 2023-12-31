USE [Dev]
GO
/****** Object:  Table [dbo].[LogActionList]    Script Date: 7/19/2023 9:02:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogActionList](
	[LogActionID] [int] NOT NULL,
	[LogActionName] [varchar](100) NOT NULL,
	[LogActionDescription] [varchar](250) NULL,
 CONSTRAINT [PK_LogActionList] PRIMARY KEY CLUSTERED 
(
	[LogActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[LogActionList] ([LogActionID], [LogActionName], [LogActionDescription]) VALUES (1, N'LOGIN', N'Login')
INSERT [dbo].[LogActionList] ([LogActionID], [LogActionName], [LogActionDescription]) VALUES (2, N'LOGOUT', N'Logout')
INSERT [dbo].[LogActionList] ([LogActionID], [LogActionName], [LogActionDescription]) VALUES (3, N'CODE_ADD', N'Add Code')
INSERT [dbo].[LogActionList] ([LogActionID], [LogActionName], [LogActionDescription]) VALUES (4, N'CODE_EDIT', N'Edit Code')
INSERT [dbo].[LogActionList] ([LogActionID], [LogActionName], [LogActionDescription]) VALUES (5, N'CODE_DEL', N'Delete Code')
INSERT [dbo].[LogActionList] ([LogActionID], [LogActionName], [LogActionDescription]) VALUES (6, N'DOC_ADD', N'Add Document')
INSERT [dbo].[LogActionList] ([LogActionID], [LogActionName], [LogActionDescription]) VALUES (7, N'DOC_EDIT', N'Edit Document')
INSERT [dbo].[LogActionList] ([LogActionID], [LogActionName], [LogActionDescription]) VALUES (8, N'DOC_DEL', N'Delete Document')
INSERT [dbo].[LogActionList] ([LogActionID], [LogActionName], [LogActionDescription]) VALUES (9, N'INVENTORY_UPLOAD', N'Inventory Upload')
GO
