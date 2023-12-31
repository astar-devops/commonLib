USE [Dev]
GO
/****** Object:  Table [dbo].[LogTypeAction]    Script Date: 7/19/2023 9:02:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTypeAction](
	[LogTypeID] [int] NOT NULL,
	[LogActionID] [int] NOT NULL,
 CONSTRAINT [PK_LogTypeAction] PRIMARY KEY CLUSTERED 
(
	[LogTypeID] ASC,
	[LogActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[LogTypeAction] ([LogTypeID], [LogActionID]) VALUES (1, 1)
INSERT [dbo].[LogTypeAction] ([LogTypeID], [LogActionID]) VALUES (1, 2)
INSERT [dbo].[LogTypeAction] ([LogTypeID], [LogActionID]) VALUES (2, 1)
INSERT [dbo].[LogTypeAction] ([LogTypeID], [LogActionID]) VALUES (2, 2)
INSERT [dbo].[LogTypeAction] ([LogTypeID], [LogActionID]) VALUES (3, 3)
INSERT [dbo].[LogTypeAction] ([LogTypeID], [LogActionID]) VALUES (3, 4)
INSERT [dbo].[LogTypeAction] ([LogTypeID], [LogActionID]) VALUES (3, 5)
INSERT [dbo].[LogTypeAction] ([LogTypeID], [LogActionID]) VALUES (4, 6)
INSERT [dbo].[LogTypeAction] ([LogTypeID], [LogActionID]) VALUES (4, 7)
INSERT [dbo].[LogTypeAction] ([LogTypeID], [LogActionID]) VALUES (4, 8)
INSERT [dbo].[LogTypeAction] ([LogTypeID], [LogActionID]) VALUES (5, 9)
GO
ALTER TABLE [dbo].[LogTypeAction]  WITH CHECK ADD  CONSTRAINT [FK_LogTypeAction_LogActionList] FOREIGN KEY([LogActionID])
REFERENCES [dbo].[LogActionList] ([LogActionID])
GO
ALTER TABLE [dbo].[LogTypeAction] CHECK CONSTRAINT [FK_LogTypeAction_LogActionList]
GO
ALTER TABLE [dbo].[LogTypeAction]  WITH CHECK ADD  CONSTRAINT [FK_LogTypeAction_LogTypeList] FOREIGN KEY([LogTypeID])
REFERENCES [dbo].[LogTypeList] ([LogTypeID])
GO
ALTER TABLE [dbo].[LogTypeAction] CHECK CONSTRAINT [FK_LogTypeAction_LogTypeList]
GO
