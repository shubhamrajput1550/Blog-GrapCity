USE [BlogDB]
GO
/****** Object:  Table [dbo].[Blog_Mst]    Script Date: 17-02-2021 22:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog_Mst](
	[PK_Blog_id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](150) NOT NULL,
	[Keyword] [varchar](250) NULL,
	[Description] [varchar](350) NULL,
	[BlogContent] [varchar](max) NOT NULL,
	[IsActive] [bit] NULL,
	[FK_User_Id] [int] NOT NULL,
 CONSTRAINT [PK_Blog_Mst] PRIMARY KEY CLUSTERED 
(
	[PK_Blog_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 17-02-2021 22:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[PK_User_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[PK_User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_User] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Blog_Mst]  WITH CHECK ADD  CONSTRAINT [FK_Blog_Mst_User] FOREIGN KEY([FK_User_Id])
REFERENCES [dbo].[User] ([PK_User_Id])
GO
ALTER TABLE [dbo].[Blog_Mst] CHECK CONSTRAINT [FK_Blog_Mst_User]
GO
