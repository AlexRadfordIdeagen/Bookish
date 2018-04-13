USE [BookishDB]
GO

/****** Object:  Table [dbo].[Checkout]    Script Date: 13/04/2018 12:43:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Checkout](
	[CheckoutID] [nchar](10) NOT NULL,
	[UserId] [nchar](10) NOT NULL,
	[TitleId] [nchar](10) NOT NULL,
	[DueDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Table_2] PRIMARY KEY CLUSTERED 
(
	[CheckoutID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Checkout]  WITH CHECK ADD  CONSTRAINT [FK_Checkout_TitleId] FOREIGN KEY([TitleId])
REFERENCES [dbo].[Book] ([TitleId])
GO

ALTER TABLE [dbo].[Checkout] CHECK CONSTRAINT [FK_Checkout_TitleId]
GO

ALTER TABLE [dbo].[Checkout]  WITH CHECK ADD  CONSTRAINT [FK_Checkout_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Checkout] CHECK CONSTRAINT [FK_Checkout_UserId]
GO


