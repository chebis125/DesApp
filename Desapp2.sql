USE [Desapp2]
GO
/****** Object:  Table [dbo].[Login_and_Register]    Script Date: 26/10/2022 22:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login_and_Register](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[frist_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](100) NULL,
	[email] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[token] [varchar](100) NULL,
 CONSTRAINT [PK__Login_an__3213E83F046F1E4E] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Missing]    Script Date: 26/10/2022 22:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Missing](
	[Id_Missing] [int] IDENTITY(1,1) NOT NULL,
	[Name__Missing] [varchar](50) NULL,
	[Age__Missing] [int] NULL,
	[Description_Missing] [varchar](max) NULL,
	[Date__Missing] [datetime] NULL,
	[Image_Missing] [varchar](max) NULL,
	[lastlocation_Missing] [varchar](100) NULL,
 CONSTRAINT [PK_Desapp] PRIMARY KEY CLUSTERED 
(
	[Id_Missing] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_Login]    Script Date: 26/10/2022 22:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_Login](@username varchar(50), @password varchar(50))
as
begin
	select * from dbo.Login_and_Register where username = @username and password = @password;
end 
GO
/****** Object:  StoredProcedure [dbo].[usp_Registration]    Script Date: 26/10/2022 22:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_Registration](@frist_name varchar(50), @last_name varchar(50), @username varchar(50), @password varchar(50), @email varchar(50), @phone int)
as
begin
	insert into dbo.Login_and_Register(frist_name, last_name, username, password, email, phone) values (@frist_name, @last_name,@username, @password, @email, @phone);
end
GO
