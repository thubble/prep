using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace prep.collections
{
  public class MovieLibrary
  {
	IList<Movie> movies;

	public MovieLibrary(IList<Movie> list_of_movies)
	{
	  this.movies = list_of_movies;
	}

	public IEnumerable<Movie> all_movies()
	{
		return (ReadOnlyCollection<Movie>) movies;
		//var newCollection = new Movie[movies.Count];
		//for (int i = 0; i < movies.Count; i++)
		//    newCollection[i] = this.movies[i].Clone();

		//return newCollection;
	}

	public void add(Movie movie)
	{
		if (movies.Contains(movie))
			return;
		foreach (var existingMovie in movies)
			if (existingMovie.title == movie.title)
				return;

		movies.Add(movie);
	}

	//public IEnumerable<Movie> Sort(Func<Movie, IComparable> sortFunction)
	//{
	//    //var returnList = new List<Movie>();
	//    //returnList.Sort()

	//    //foreach (var movie in movies)
	//    //    if (sortFunction(movie))
	//    //        returnList.Add(movie);

	//    //return returnList;
	//}

	public IEnumerable<Movie> Filter(Func<Movie, bool> filterFunction)
	{
		var returnList = new List<Movie>();

		foreach (var movie in movies)
			if (filterFunction(movie))
				returnList.Add(movie);

		return returnList;
	}

	public IEnumerable<Movie> sort_all_movies_by_title_descending()
	{
		throw new NotImplementedException();
	}

	public IEnumerable<Movie> all_movies_published_by_pixar()
	{
		throw new NotImplementedException();
	}

	public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
	{
		return Filter(m => m.production_studio == ProductionStudio.Pixar || m.production_studio == ProductionStudio.Disney);
	}

	public IEnumerable<Movie> sort_all_movies_by_title_ascending()
	{
	  throw new NotImplementedException();
	}

	public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
	{
	  throw new NotImplementedException();
	}

	public IEnumerable<Movie> all_movies_not_published_by_pixar()
	{
		return Filter(m => m.production_studio != ProductionStudio.Pixar);
	}

	public IEnumerable<Movie> all_movies_published_after(int year)
	{
		return Filter(m => m.date_published.Year > year);
	}

	public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
	{
		return Filter(m => m.date_published.Year >= startingYear && m.date_published.Year <= endingYear);
	}

	public IEnumerable<Movie> all_kid_movies()
	{
		return Filter(m => m.genre == Genre.kids);
	}

	public IEnumerable<Movie> all_action_movies()
	{
		return Filter(m => m.genre == Genre.action);
	}

	public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
	{
	  throw new NotImplementedException();
	}

	public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
	{
	  throw new NotImplementedException();
	}
  }
}