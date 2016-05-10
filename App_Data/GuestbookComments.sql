﻿CREATE TABLE [dbo].[GuestbookComments]
(
	[CommentId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Subject] NVARCHAR(50) NOT NULL, 
    [Body] NVARCHAR(MAX) NOT NULL, 
    [CommentDate] DATETIME NOT NULL DEFAULT getdate(), 
    [UserId] UNIQUEIDENTIFIER NOT NULL
)
