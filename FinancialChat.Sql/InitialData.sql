USE [FinancialChatDB]
GO
SET IDENTITY_INSERT [dbo].[UserIdentity] ON 
GO
INSERT [dbo].[UserIdentity] ([Id], [Name], [Password], [CreatedDate]) VALUES (1, N'bot_internal', N'NzVvZlJqbDV1Rg==', CAST(N'2022-03-27' AS Date))
GO
INSERT [dbo].[UserIdentity] ([Id], [Name], [Password], [CreatedDate]) VALUES (2, N'edwin', N'bkdqcDNtOFRMVg==', CAST(N'2022-03-27' AS Date))
GO
INSERT [dbo].[UserIdentity] ([Id], [Name], [Password], [CreatedDate]) VALUES (3, N'snd_user', N'VFVQNEh4bEs0RA==', CAST(N'2022-03-27' AS Date))
GO
SET IDENTITY_INSERT [dbo].[UserIdentity] OFF
GO
SET IDENTITY_INSERT [dbo].[MessageChat] ON 
GO
INSERT [dbo].[MessageChat] ([Id], [FromUser], [ToUser], [Message], [CreatedDate]) VALUES (1, 1, 1, N'first messag', CAST(N'2022-03-27T16:47:57.143' AS DateTime))
GO
INSERT [dbo].[MessageChat] ([Id], [FromUser], [ToUser], [Message], [CreatedDate]) VALUES (2, 1, 1, N'other message', CAST(N'2022-03-27T16:48:20.887' AS DateTime))
GO
INSERT [dbo].[MessageChat] ([Id], [FromUser], [ToUser], [Message], [CreatedDate]) VALUES (3, 1, 1, N'hello world', CAST(N'2022-03-28T01:14:30.883' AS DateTime))
GO
INSERT [dbo].[MessageChat] ([Id], [FromUser], [ToUser], [Message], [CreatedDate]) VALUES (4, 1, 1, N'/stock=A_STOCK', CAST(N'2022-03-28T01:15:34.130' AS DateTime))
GO
INSERT [dbo].[MessageChat] ([Id], [FromUser], [ToUser], [Message], [CreatedDate]) VALUES (5, 1, 1, N'A_STOCK', CAST(N'2022-03-28T03:27:16.087' AS DateTime))
GO
INSERT [dbo].[MessageChat] ([Id], [FromUser], [ToUser], [Message], [CreatedDate]) VALUES (6, 1, 2, N'AAPL.US quote is $174.72 per share', CAST(N'2022-03-28T03:27:20.227' AS DateTime))
GO
INSERT [dbo].[MessageChat] ([Id], [FromUser], [ToUser], [Message], [CreatedDate]) VALUES (7, 1, 2, N'AAPL.US quote is $174.72 per share', CAST(N'2022-03-28T12:10:55.780' AS DateTime))
GO
INSERT [dbo].[MessageChat] ([Id], [FromUser], [ToUser], [Message], [CreatedDate]) VALUES (8, 1, 2, N'AAPL.US quote is $174.72 per share', CAST(N'2022-03-28T12:10:58.400' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[MessageChat] OFF
GO
