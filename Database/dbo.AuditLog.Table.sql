USE [Dev]
GO
/****** Object:  Table [dbo].[AuditLog]    Script Date: 8/10/2023 3:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditLog](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[DeviceID] [varchar](50) NULL,
	[IPAddress] [varchar](30) NULL,
	[LogDateTime] [datetime] NOT NULL,
	[LogTypeID] [int] NOT NULL,
	[LogActionID] [int] NOT NULL,
	[ActionRequest] [nvarchar](max) NULL,
	[ActionResponse] [nvarchar](max) NULL,
	[Status] [char](1) NULL,
	[ErrorCode] [varchar](10) NULL,
	[ErrorDescription] [varchar](max) NULL,
	[RefID] [varchar](50) NULL,
 CONSTRAINT [PK_AuditLog] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AuditLog] ON 

INSERT [dbo].[AuditLog] ([LogID], [UserID], [DeviceID], [IPAddress], [LogDateTime], [LogTypeID], [LogActionID], [ActionRequest], [ActionResponse], [Status], [ErrorCode], [ErrorDescription], [RefID]) VALUES (1, 1, N'M-AHQ-XXXX', N'192.168.xxx.xxx', CAST(N'2023-06-13T14:05:20.623' AS DateTime), 1, 1, N'{ 
	"userName": "username123",
	"deviceID": "M-AHQ-XXXXX"
}', N'{
	"badLogonCount": 1,
	"errorCode": "1",
	"isSuccess": false,
	"errorMessage": {
		"Message": "Invalid username/password"
	}
}', N'E', N'1', N'Invalid username/password', NULL)
INSERT [dbo].[AuditLog] ([LogID], [UserID], [DeviceID], [IPAddress], [LogDateTime], [LogTypeID], [LogActionID], [ActionRequest], [ActionResponse], [Status], [ErrorCode], [ErrorDescription], [RefID]) VALUES (2, 1, N'AHQ-XXXXX', N'192.168.xxx.xxx', CAST(N'2023-06-13T14:30:06.127' AS DateTime), 2, 1, N'{ 
	"UserID": "1",
	"AccessRights": ["ADMIN", "EDIT"]
}', NULL, N'S', NULL, NULL, NULL)
INSERT [dbo].[AuditLog] ([LogID], [UserID], [DeviceID], [IPAddress], [LogDateTime], [LogTypeID], [LogActionID], [ActionRequest], [ActionResponse], [Status], [ErrorCode], [ErrorDescription], [RefID]) VALUES (3, 1, N'AHQ-XXXXX', N'192.168.xxx.xxx', CAST(N'2023-06-13T15:30:03.657' AS DateTime), 2, 2, NULL, NULL, N'S', NULL, NULL, NULL)
INSERT [dbo].[AuditLog] ([LogID], [UserID], [DeviceID], [IPAddress], [LogDateTime], [LogTypeID], [LogActionID], [ActionRequest], [ActionResponse], [Status], [ErrorCode], [ErrorDescription], [RefID]) VALUES (4, 2, N'AHQ-XXXXX', N'192.168.xxx.xxx', CAST(N'2023-06-13T15:33:10.090' AS DateTime), 3, 3, N'{ 
	"PK": [
		{
			"FieldName": "Code",
			"Value": "1"
		},
		{
			"FieldName": "Key1",
			"Value": "A"
		}
	],
	"Columns": [
		{
			"FieldName": "CodeValue",
			"Value": "test value"
		},
		{
			"FieldName": "CodeDescription",
			"Value": "test desc"
		}
	]
}', NULL, N'S', NULL, NULL, NULL)
INSERT [dbo].[AuditLog] ([LogID], [UserID], [DeviceID], [IPAddress], [LogDateTime], [LogTypeID], [LogActionID], [ActionRequest], [ActionResponse], [Status], [ErrorCode], [ErrorDescription], [RefID]) VALUES (5, 2, N'AHQ-XXXXX', N'192.168.xxx.xxx', CAST(N'2023-06-13T15:38:48.953' AS DateTime), 3, 4, N'{ 
	"PK": [
		{
			"FieldName": "Code",
			"Value": "1"
		},
		{
			"FieldName": "Key1",
			"Value": "A"
		}
	],
	"Columns": [
		{
			"FieldName": "CodeDescription",
			"Value": "test desc~test desc 1"
		}
	]
}', NULL, N'S', NULL, NULL, NULL)
INSERT [dbo].[AuditLog] ([LogID], [UserID], [DeviceID], [IPAddress], [LogDateTime], [LogTypeID], [LogActionID], [ActionRequest], [ActionResponse], [Status], [ErrorCode], [ErrorDescription], [RefID]) VALUES (6, 3, N'AHQ-XXXXX', N'192.168.xxx.xxx', CAST(N'2023-06-13T15:40:38.557' AS DateTime), 3, 5, N'{ 
	"PK": [
		{
			"FieldName": "Code",
			"Value": "1"
		},
		{
			"FieldName": "Key1",
			"Value": "A"
		}
	],
	"Columns": [
		{
			"FieldName": "CodeValue",
			"Value": "test value"
		},
		{
			"FieldName": "CodeDescription",
			"Value": "test desc 1"
		}
	]
}', NULL, N'S', NULL, NULL, NULL)
INSERT [dbo].[AuditLog] ([LogID], [UserID], [DeviceID], [IPAddress], [LogDateTime], [LogTypeID], [LogActionID], [ActionRequest], [ActionResponse], [Status], [ErrorCode], [ErrorDescription], [RefID]) VALUES (7, 2, N'AHQ-XXXXX', N'192.168.xxx.xxx', CAST(N'2023-06-13T15:45:37.650' AS DateTime), 4, 6, N'{ 
	"PK": [
		{
			"FieldName": "DocumentID",
			"Value": "1"
		}
	],
	"Columns": [
		{
			"FieldName": "DocumentType",
			"Value": "training type"
		},
		{
			"FieldName": "DocumentName",
			"Value": "trainig doc"
		},
		{
			"FieldName": "DocumentFileName",
			"Value": "Training Document.pdf"
		}
	]
}', NULL, N'S', NULL, NULL, NULL)
INSERT [dbo].[AuditLog] ([LogID], [UserID], [DeviceID], [IPAddress], [LogDateTime], [LogTypeID], [LogActionID], [ActionRequest], [ActionResponse], [Status], [ErrorCode], [ErrorDescription], [RefID]) VALUES (8, 3, N'AHQ-XXXXX', N'192.168.xxx.xxx', CAST(N'2023-06-13T15:50:35.787' AS DateTime), 4, 7, N'{ 
	"PK": [
		{
			"FieldName": "DocumentID",
			"Value": "1"
		}
	],
	"Columns": [
		{
			"FieldName": "DocumentType",
			"Value": "training type~training type"
		},
		{
			"FieldName": "DocumentName",
			"Value": "trainig doc~training doc v1"
		}
	]
}', NULL, N'S', NULL, NULL, NULL)
INSERT [dbo].[AuditLog] ([LogID], [UserID], [DeviceID], [IPAddress], [LogDateTime], [LogTypeID], [LogActionID], [ActionRequest], [ActionResponse], [Status], [ErrorCode], [ErrorDescription], [RefID]) VALUES (9, 2, N'AHQ-XXXXX', N'192.168.xxx.xxx', CAST(N'2023-06-13T15:53:47.510' AS DateTime), 4, 8, N'{ 
	"PK": [
		{
			"FieldName": "DocumentID",
			"Value": "1"
		}
	],
	"Columns": [
		{
			"FieldName": "DocumentType",
			"Value": "training type"
		},
		{
			"FieldName": "DocumentName",
			"Value": "trainig doc v1"
		},
		{
			"FieldName": "DocumentFileName",
			"Value": "Training Document.pdf"
		}
	]
}', NULL, N'E', NULL, N'Error message details', NULL)
INSERT [dbo].[AuditLog] ([LogID], [UserID], [DeviceID], [IPAddress], [LogDateTime], [LogTypeID], [LogActionID], [ActionRequest], [ActionResponse], [Status], [ErrorCode], [ErrorDescription], [RefID]) VALUES (10, 3, N'AHQ-XXXXX', N'192.168.xxx.xxx', CAST(N'2023-06-13T16:05:49.107' AS DateTime), 5, 9, N'{ 
	"DocumentName": "Inventory batch upload.csv,
	"Columns": [
		{
			"InventoryID": "1",
			"Inventory": {
				"FieldName": "Name",
				"Value": "null~Inventory A"
			}
		},
		{
			"InventoryID": "2",
			"Inventory": {
				"FieldName": "Name",
				"Value": "Inventory A~Inventory B"
			}
		}
	]
}', NULL, N'S', NULL, NULL, NULL)
INSERT [dbo].[AuditLog] ([LogID], [UserID], [DeviceID], [IPAddress], [LogDateTime], [LogTypeID], [LogActionID], [ActionRequest], [ActionResponse], [Status], [ErrorCode], [ErrorDescription], [RefID]) VALUES (11, 1, N'AHQ-XXXXX', N'192.168.xxx.xxx', CAST(N'2023-08-10T14:39:46.673' AS DateTime), 3, 3, N'{
  "PK": [
    {
      "FieldName": "Code",
      "Value": "1"
    },
    {
      "FieldName": "Key1",
      "Value": "A"
    }
  ],
  "Columns": [
    {
      "FieldName": "CodeValue",
      "Value": "test value"
    },
    {
      "FieldName": "CodeDescription",
      "Value": "test desc"
    }
  ]
}', NULL, N'S', NULL, NULL, N'SYSA202308101439461475')
INSERT [dbo].[AuditLog] ([LogID], [UserID], [DeviceID], [IPAddress], [LogDateTime], [LogTypeID], [LogActionID], [ActionRequest], [ActionResponse], [Status], [ErrorCode], [ErrorDescription], [RefID]) VALUES (12, 1, N'AHQ-XXXXX', N'192.168.xxx.xxx', CAST(N'2023-08-10T14:41:56.513' AS DateTime), 3, 3, N'{
  "PK": [
    {
      "FieldName": "Code",
      "Value": "1"
    },
    {
      "FieldName": "Key1",
      "Value": "A"
    }
  ],
  "Columns": [
    {
      "FieldName": "CodeValue",
      "Value": "test value"
    },
    {
      "FieldName": "CodeDescription",
      "Value": "test desc"
    }
  ]
}', NULL, N'E', NULL, N'An error occurred while saving the entity changes. See the inner exception for details.', N'SYSA202308101441562918')
INSERT [dbo].[AuditLog] ([LogID], [UserID], [DeviceID], [IPAddress], [LogDateTime], [LogTypeID], [LogActionID], [ActionRequest], [ActionResponse], [Status], [ErrorCode], [ErrorDescription], [RefID]) VALUES (13, 1, N'AHQ-XXXXX', N'192.168.xxx.xxx', CAST(N'2023-08-10T14:43:03.467' AS DateTime), 3, 4, N'{
  "PK": [
    {
      "FieldName": "Code",
      "Value": "1"
    },
    {
      "FieldName": "Key1",
      "Value": "A"
    }
  ],
  "Columns": [
    {
      "FieldName": "CodeDescription",
      "Value": "test desc~test desc 1"
    }
  ]
}', NULL, N'S', NULL, NULL, NULL)
INSERT [dbo].[AuditLog] ([LogID], [UserID], [DeviceID], [IPAddress], [LogDateTime], [LogTypeID], [LogActionID], [ActionRequest], [ActionResponse], [Status], [ErrorCode], [ErrorDescription], [RefID]) VALUES (14, 1, N'AHQ-XXXXX', N'192.168.xxx.xxx', CAST(N'2023-08-10T14:43:35.517' AS DateTime), 3, 5, N'{
  "PK": [
    {
      "FieldName": "Code",
      "Value": "1"
    },
    {
      "FieldName": "Key1",
      "Value": "A"
    }
  ],
  "Columns": [
    {
      "FieldName": "CodeValue",
      "Value": "test value"
    },
    {
      "FieldName": "CodeDescription",
      "Value": "test desc 1"
    }
  ]
}', NULL, N'S', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AuditLog] OFF
GO
ALTER TABLE [dbo].[AuditLog]  WITH CHECK ADD  CONSTRAINT [FK_AuditLog_LogActionList] FOREIGN KEY([LogActionID])
REFERENCES [dbo].[LogActionList] ([LogActionID])
GO
ALTER TABLE [dbo].[AuditLog] CHECK CONSTRAINT [FK_AuditLog_LogActionList]
GO
ALTER TABLE [dbo].[AuditLog]  WITH CHECK ADD  CONSTRAINT [FK_AuditLog_LogTypeList] FOREIGN KEY([LogTypeID])
REFERENCES [dbo].[LogTypeList] ([LogTypeID])
GO
ALTER TABLE [dbo].[AuditLog] CHECK CONSTRAINT [FK_AuditLog_LogTypeList]
GO
