USE [MoviesDB]
GO

SELECT *
  FROM [MoviesDB].[dbo].[Movies]
    where ExternalId=13701

SELECT *
  FROM [MoviesDB].[dbo].[Movies]
  where Title like '%avengers%'
  order by Popularity desc

SELECT *
  FROM [dbo].[Genres]
GO

--delete from Genres where id > 20
--truncate table [dbo].[GenreMovies]

SELECT *
  FROM [MoviesDB].[dbo].[Casts]
  where id =304291

SELECT *
  FROM [dbo].[MovieCasts]
  where MovieId=246
GO


SELECT id,
      OriginalTitle
      ,[AverageVote]
	  , Popularity
      
  FROM [MoviesDB].[dbo].[Movies]
  order by Popularity desc


--truncate table [MovieCasts]