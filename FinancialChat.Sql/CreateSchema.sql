USE [FinancialChatDB]
GO
/****** Object:  Table [dbo].[MessageChat]    Script Date: 3/27/2022 11:58:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageChat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FromUser] [int] NOT NULL,
	[ToUser] [int] NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_CreditCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserIdentity]    Script Date: 3/27/2022 11:58:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserIdentity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[CreatedDate] [date] NULL,
 CONSTRAINT [PK_UserIdentity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MessageChat]  WITH CHECK ADD  CONSTRAINT [FK_MessageChat_UserIdentity] FOREIGN KEY([FromUser])
REFERENCES [dbo].[UserIdentity] ([Id])
GO
ALTER TABLE [dbo].[MessageChat] CHECK CONSTRAINT [FK_MessageChat_UserIdentity]
GO
ALTER TABLE [dbo].[MessageChat]  WITH CHECK ADD  CONSTRAINT [FK_MessageChat_UserIdentity1] FOREIGN KEY([ToUser])
REFERENCES [dbo].[UserIdentity] ([Id])
GO
ALTER TABLE [dbo].[MessageChat] CHECK CONSTRAINT [FK_MessageChat_UserIdentity1]
GO
USE [master]
GO
ALTER DATABASE [FinancialChatDB] SET  READ_WRITE 
GO