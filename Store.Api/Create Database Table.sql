/****** Db scripted table  ******/
USE [DeanAndDaughtersLtd]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Author] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

INSERT INTO Books (Author, Title, Price) VALUES (N'A. A. Milne', N'Winnie-the-Pooh', 19.25)
INSERT INTO Books (Author, Title, Price) VALUES (N'Jane Austen', N'Pride and Prejudice', 5.49)
INSERT INTO Books (Author, Title, Price) VALUES (N'William Shakespeare', N'Romeo and Juliet', 6.95)
