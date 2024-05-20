USE [Knjiznica]
GO
/****** Object:  Table [dbo].[članovi]    Script Date: 17.05.2024 20:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[članovi](
	[član_id] [int] NOT NULL,
	[ime] [varchar](50) NULL,
	[prezime] [varchar](50) NULL,
	[adresa_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[član_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kategorije_knjiga]    Script Date: 17.05.2024 20:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kategorije_knjiga](
	[kategorija_id] [int] NOT NULL,
	[naziv] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[kategorija_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[knjige]    Script Date: 17.05.2024 20:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[knjige](
	[knjiga_id] [int] NOT NULL,
	[naslov] [varchar](100) NULL,
	[autor] [varchar](100) NULL,
	[kategorija_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[knjiga_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mjesta_stanovanja]    Script Date: 17.05.2024 20:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mjesta_stanovanja](
	[adresa_id] [int] NOT NULL,
	[grad] [varchar](50) NULL,
	[država] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[adresa_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posudbe]    Script Date: 17.05.2024 20:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posudbe](
	[posudba_id] [int] NOT NULL,
	[član_id] [int] NULL,
	[knjiga_id] [int] NULL,
	[datum_posudbe] [date] NULL,
	[datum_vraćanja] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[posudba_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[članovi]  WITH CHECK ADD FOREIGN KEY([adresa_id])
REFERENCES [dbo].[mjesta_stanovanja] ([adresa_id])
GO
ALTER TABLE [dbo].[knjige]  WITH CHECK ADD FOREIGN KEY([kategorija_id])
REFERENCES [dbo].[kategorije_knjiga] ([kategorija_id])
GO
ALTER TABLE [dbo].[posudbe]  WITH CHECK ADD FOREIGN KEY([član_id])
REFERENCES [dbo].[članovi] ([član_id])
GO
ALTER TABLE [dbo].[posudbe]  WITH CHECK ADD FOREIGN KEY([knjiga_id])
REFERENCES [dbo].[knjige] ([knjiga_id])
GO
USE [master]
GO
ALTER DATABASE [Knjiznica] SET  READ_WRITE 
GO

-- Users have been added through console app
-- Create the table
CREATE TABLE mjesta_stanovanja (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    grad NVARCHAR(100),
    država NVARCHAR(100)
);

CREATE TABLE knjige (
    knjiga_id INT IDENTITY(1,1) PRIMARY KEY,
    naslov NVARCHAR(255),
    autor NVARCHAR(255),
    kategorija_id INT
);

CREATE TABLE kategorije_knjiga (
    kategorija_id INT IDENTITY(1,1) PRIMARY KEY,
    naziv NVARCHAR(255)
);

CREATE TABLE posudbe (
    posudba_id INT IDENTITY(1,1) PRIMARY KEY,
    član_id INT,
    datum_posudbe DATE,
    datum_vraćanja DATE
);

-- Insert records
INSERT INTO posudbe (član_id, datum_posudbe, datum_vraćanja)
VALUES
    (1, '2024-01-05', '2024-01-07'),
    (3, '2024-02-10', '2024-02-15'),
    (5, '2024-03-20', '2024-03-25'),
    (7, '2024-04-12', NULL),
    (9, '2024-05-18', NULL);


INSERT INTO kategorije_knjiga (naziv)
VALUES
    ('Science Fiction'),
    ('Romance'),
    ('Mystery'),
    ('Fantasy'),
    ('Non-Fiction');


INSERT INTO knjige (naslov, autor, kategorija_id)
VALUES
    ('1984', 'George Orwell', FLOOR(RAND() * 3) + 1),
    ('Pride and Prejudice', 'Jane Austen', FLOOR(RAND() * 3) + 1),
    ('To Kill a Mockingbird', 'Harper Lee', FLOOR(RAND() * 3) + 1),
    ('Moby-Dick', 'Herman Melville', FLOOR(RAND() * 3) + 1),
    ('The Great Gatsby', 'F. Scott Fitzgerald', FLOOR(RAND() * 3) + 1);


INSERT INTO mjesta_stanovanja (grad, država)
VALUES
    ('Zagreb', 'Hrvatska'),
    ('Split', 'Hrvatska'),
    ('Rijeka', 'Hrvatska'),
    ('Osijek', 'Hrvatska'),
    ('Zadar', 'Hrvatska');
