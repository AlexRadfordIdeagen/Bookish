USE [BookishDB]
GO

/****** Object:  Table [dbo].[Book]    Script Date: 13/04/2018 12:45:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Book](
	[TitleId] [nchar](10) NOT NULL,
	[NoOfBooks] [smallint] NOT NULL,
	[Author] [nchar](32) NOT NULL,
	[Title] [nchar](32) NOT NULL,
	[ISBN] [nchar](13) NOT NULL,
 CONSTRAINT [PK_Table_3] PRIMARY KEY CLUSTERED 
(
	[TitleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


