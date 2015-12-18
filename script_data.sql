USE [att_khovd_drama_db]
GO
/****** Object:  Table [dbo].[tComment]    Script Date: 2015-12-17 01:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tComment](
	[comment_id] [int] IDENTITY(11,1) NOT NULL,
	[news_ids] [int] NULL,
	[name] [nvarchar](100) NULL,
	[e-mails] [nvarchar](200) NULL,
	[comment] [nchar](400) NULL,
	[addedcomment] [datetime] NULL,
	[http_posted] [nvarchar](50) NULL,
 CONSTRAINT [PK_tComment] PRIMARY KEY CLUSTERED 
(
	[comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tMenu]    Script Date: 2015-12-17 01:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tMenu](
	[menu_id] [int] IDENTITY(1000,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[Url] [nvarchar](max) NULL,
	[images] [nvarchar](max) NULL,
	[addeddate] [datetime] NULL,
 CONSTRAINT [PK_tMenu] PRIMARY KEY CLUSTERED 
(
	[menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tNews]    Script Date: 2015-12-17 01:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNews](
	[news_id] [int] IDENTITY(403,1) NOT NULL,
	[subs_id] [int] NULL,
	[menus_ids] [int] NULL,
	[title] [nvarchar](150) NULL,
	[title_more] [nvarchar](250) NULL,
	[detials] [nvarchar](max) NULL,
	[images] [nvarchar](max) NULL,
	[addedtime] [datetime] NULL,
	[news_count] [int] NULL,
	[news_video] [nvarchar](max) NULL,
	[news_audio] [nvarchar](max) NULL,
 CONSTRAINT [PK_tNews] PRIMARY KEY CLUSTERED 
(
	[news_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tSubmenu]    Script Date: 2015-12-17 01:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tSubmenu](
	[sub_id] [int] IDENTITY(100,1) NOT NULL,
	[menus_id] [int] NULL,
	[name] [nvarchar](50) NULL,
	[url] [nvarchar](max) NULL,
	[images] [nvarchar](max) NULL,
	[addedtime] [datetime] NULL,
 CONSTRAINT [PK_tSubmenu] PRIMARY KEY CLUSTERED 
(
	[sub_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tMenu] ON 

INSERT [dbo].[tMenu] ([menu_id], [name], [Url], [images], [addeddate]) VALUES (1000, N'ХУУЛИЙН САН', NULL, NULL, CAST(N'2015-12-12 23:47:00.890' AS DateTime))
INSERT [dbo].[tMenu] ([menu_id], [name], [Url], [images], [addeddate]) VALUES (1001, N'ЭРҮҮЛ МЭНД', NULL, NULL, CAST(N'2015-12-12 23:47:40.537' AS DateTime))
INSERT [dbo].[tMenu] ([menu_id], [name], [Url], [images], [addeddate]) VALUES (1002, N'ЗӨВЛӨГӨӨ', NULL, NULL, CAST(N'2015-12-12 23:47:50.073' AS DateTime))
INSERT [dbo].[tMenu] ([menu_id], [name], [Url], [images], [addeddate]) VALUES (1003, N'СУРГАЛТ', NULL, NULL, CAST(N'2015-12-13 00:02:19.367' AS DateTime))
INSERT [dbo].[tMenu] ([menu_id], [name], [Url], [images], [addeddate]) VALUES (1004, N'МЭДЭЭЛЭЛ', NULL, NULL, CAST(N'2015-12-13 00:02:28.803' AS DateTime))
INSERT [dbo].[tMenu] ([menu_id], [name], [Url], [images], [addeddate]) VALUES (1005, N'БИЧЛЭГ', NULL, NULL, CAST(N'2015-12-13 00:02:52.920' AS DateTime))
SET IDENTITY_INSERT [dbo].[tMenu] OFF
SET IDENTITY_INSERT [dbo].[tNews] ON 

INSERT [dbo].[tNews] ([news_id], [subs_id], [menus_ids], [title], [title_more], [detials], [images], [addedtime], [news_count], [news_video], [news_audio]) VALUES (403, 101, 1000, N' Архины тухай мэргэд', N'Сайхан хаягтай, ганган савтай дарс гэдэг бол гоо бэлхүүстэй, торгон нөмрөгтэй шулам гэсэн. Түүнд битгий хууртаарай', N'<div class="photo-show"><img src="http://sonin.mn/uploads/news/201203/21/527-1332329521arhichin-bolod.mn_.jpg" />
<p>&nbsp;</p>
</div>
Согтуу явахад нартай хорвоо ч харанхуй санагдана<br />
(С.Есенин)<br />
<br />
Сайхан хаягтай, ганган савтай дарс гэдэг бол гоо бэлхүүстэй, торгон нөмрөгтэй шулам гэсэн. Түүнд битгий хууртаарай<br />
(М.Твен)<br />
<br />
Би хуучин нийгмээс гурван зүйлийг халахыг хүсч байна.<br />
<br />
1-рт дарлалыг хална<br />
<br />
2-ртшуналыг хална<br />
<br />
3-ртархийг хална тэгвэл юм бүхэн сайн сайхан болно.<br />
(Достоевский)<br />
<br />
Архи хэмээгч угаас ёсыг алдуулан ёрыг өрнүүлэхийн үндэс мөн.<br />
(Д.Сүхбаатар)<br />
<br />
Хүн яагаад архинд автагдаж байна вэ? Түүний шалтгааны уг сурвалж нь амьдралын тулалдаанд нугарсан сэтгэлийн ялагдал юм шүү.<br />
(Ж.Лондон)<br />
<br />
Согтуурна гэдэг галзуурахын тулд дасгал сургууль хийж байгаа хэрэг<br />
(А.Франс)<br />
<br />
Анхны хундагыг эрүүл мэндийн төлөө, хоёрдугаарыг нь зугаа цэнгэлийн төлөө, дараачийнхыг нь адгуус мал, албин шулмас болохын төлөө өргөдөг<br />
(А.Л.Толстой)<br />
<br />
Хүний гэрэлт авьяас руу архи дайрахдаа тун хорхойтой байдаг. Учир, нь авьяас гэдэг бол оюун ухааны амтат бал бурам юм шүү дээ.<br />
(М.Горький)<br />
<br />
Бид бие биенийхээ сайн сайхны төлөө хундага тулгаж байгаа юм бишээ, харин бие биенийгээ түргэн шиг устган тонилгохын төлөө хутга дүрж байгаа юм гэдгийг санагтун<br />
(Б.Спок)', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tNews] OFF
SET IDENTITY_INSERT [dbo].[tSubmenu] ON 

INSERT [dbo].[tSubmenu] ([sub_id], [menus_id], [name], [url], [images], [addedtime]) VALUES (100, 1001, N'эмч зөвлөж байна', NULL, NULL, CAST(N'2015-12-12 23:54:07.467' AS DateTime))
INSERT [dbo].[tSubmenu] ([sub_id], [menus_id], [name], [url], [images], [addedtime]) VALUES (101, 1000, N'их засаг хуулинд', NULL, NULL, CAST(N'2015-12-12 23:57:51.640' AS DateTime))
INSERT [dbo].[tSubmenu] ([sub_id], [menus_id], [name], [url], [images], [addedtime]) VALUES (102, 1002, N'архинаас гарах арга', NULL, NULL, CAST(N'2015-12-12 23:58:04.583' AS DateTime))
INSERT [dbo].[tSubmenu] ([sub_id], [menus_id], [name], [url], [images], [addedtime]) VALUES (103, 1001, N'архи, тамхины хор уршиг', NULL, NULL, CAST(N'2015-12-12 00:00:00.000' AS DateTime))
INSERT [dbo].[tSubmenu] ([sub_id], [menus_id], [name], [url], [images], [addedtime]) VALUES (104, 1003, N'Байгууллагууд', NULL, NULL, CAST(N'2015-12-13 00:00:00.000' AS DateTime))
INSERT [dbo].[tSubmenu] ([sub_id], [menus_id], [name], [url], [images], [addedtime]) VALUES (105, 1004, N'цаг үеийн', NULL, NULL, CAST(N'2015-12-13 00:03:54.720' AS DateTime))
INSERT [dbo].[tSubmenu] ([sub_id], [menus_id], [name], [url], [images], [addedtime]) VALUES (106, 1005, N'Архитай холбоотой', NULL, NULL, CAST(N'2015-12-13 00:00:00.000' AS DateTime))
INSERT [dbo].[tSubmenu] ([sub_id], [menus_id], [name], [url], [images], [addedtime]) VALUES (107, 1000, N'архидан согтуурахтай тэмцэх тухай хууль', NULL, NULL, CAST(N'2015-12-13 00:07:01.247' AS DateTime))
INSERT [dbo].[tSubmenu] ([sub_id], [menus_id], [name], [url], [images], [addedtime]) VALUES (108, 1000, N'эрүүгийн хуулинд', NULL, NULL, CAST(N'2015-12-13 00:07:50.677' AS DateTime))
INSERT [dbo].[tSubmenu] ([sub_id], [menus_id], [name], [url], [images], [addedtime]) VALUES (109, 1000, N'хөдөлгөөний аюулгүй байдлын тухай хууль', NULL, NULL, CAST(N'2015-12-13 00:08:16.497' AS DateTime))
INSERT [dbo].[tSubmenu] ([sub_id], [menus_id], [name], [url], [images], [addedtime]) VALUES (110, 1000, N'захиргааны хариуцлагын тухай хууль', NULL, NULL, CAST(N'2015-12-13 00:08:41.517' AS DateTime))
INSERT [dbo].[tSubmenu] ([sub_id], [menus_id], [name], [url], [images], [addedtime]) VALUES (111, 1000, N'бусад', NULL, NULL, CAST(N'2015-12-13 00:08:52.090' AS DateTime))
INSERT [dbo].[tSubmenu] ([sub_id], [menus_id], [name], [url], [images], [addedtime]) VALUES (112, 1005, N'Тамхитай холбоотой', NULL, NULL, CAST(N'2015-12-13 00:28:39.777' AS DateTime))
SET IDENTITY_INSERT [dbo].[tSubmenu] OFF
ALTER TABLE [dbo].[tComment]  WITH CHECK ADD  CONSTRAINT [FK_tComment_tNews1] FOREIGN KEY([news_ids])
REFERENCES [dbo].[tNews] ([news_id])
GO
ALTER TABLE [dbo].[tComment] CHECK CONSTRAINT [FK_tComment_tNews1]
GO
ALTER TABLE [dbo].[tNews]  WITH CHECK ADD  CONSTRAINT [FK_tNews_tMenu] FOREIGN KEY([menus_ids])
REFERENCES [dbo].[tMenu] ([menu_id])
GO
ALTER TABLE [dbo].[tNews] CHECK CONSTRAINT [FK_tNews_tMenu]
GO
ALTER TABLE [dbo].[tNews]  WITH CHECK ADD  CONSTRAINT [FK_tNews_tSubmenu] FOREIGN KEY([subs_id])
REFERENCES [dbo].[tSubmenu] ([sub_id])
GO
ALTER TABLE [dbo].[tNews] CHECK CONSTRAINT [FK_tNews_tSubmenu]
GO
ALTER TABLE [dbo].[tSubmenu]  WITH CHECK ADD  CONSTRAINT [FK_tSubmenu_tMenu] FOREIGN KEY([menus_id])
REFERENCES [dbo].[tMenu] ([menu_id])
GO
ALTER TABLE [dbo].[tSubmenu] CHECK CONSTRAINT [FK_tSubmenu_tMenu]
GO
