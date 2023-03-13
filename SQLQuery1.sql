DECLARE @theatre_name as varchar(50) = 'IMax'
select sum(s.Cost) as [Earnings] from [dbo].[Show] s
inner join [dbo].[Screen] sc on s.Screen_ScreenId = sc.ScreenId
inner join [dbo].[Theatre] th on th.TheatreId = sc.Theatre_TheatreId
inner join [dbo].[Booking] b on b.Show_ShowId = s.ShowId
where th.TheatreName = @theatre_name

--select * from [dbo].[Booking]