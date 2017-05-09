USE [Gam3ia]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'admin')

GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'365e6ac5-be49-453d-b67e-07285a012962', N'admin@gmail.com', 0, N'AJ5zQ8wfLOxlDQO5cYdHji7QCZywkSfVo7lgLtO3olMLrnLER5iD7fKzEiXElGqy1A==', N'b5e08f16-35be-450e-b79c-6190bbfeaa0e', NULL, 0, 0, NULL, 1, 0, N'admin')

GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'365e6ac5-be49-453d-b67e-07285a012962', N'1')
GO
