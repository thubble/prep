using System;
using System.Collections.Generic;
using prep.utility;

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
	  return movies.one_at_a_time();
	}

	public void add(Movie movie)
	{
	  if (already_contains(movie)) return;

	  movies.Add(movie);
	}

	bool already_contains(Movie movie)
	{
	  return movies.Contains(movie);
	}


	private class SortComparer<TItem> : IComparer<TItem>
	{
		private readonly Func<TItem, TItem, int> comparison;

		public SortComparer(Func<TItem, TItem, int> comparison)
		{
			this.comparison = comparison;
		}

		public int Compare(TItem x, TItem y)
		{
			return comparison(x, y);
		}
	}

	public IEnumerable<Movie> Sort(Func<Movie, Movie, int> sortFunction, IEnumerable<Movie> source = null)
	{
		var list = new List<Movie>(source ?? movies);
		list.Sort(new SortComparer<Movie>(sortFunction));
		return list;
	}

	public IEnumerable<Movie> sort_all_movies_by_title_descending()
	{
		return Sort((m1, m2) => -1 * m1.title.CompareTo(m2.title));
	}

	public IEnumerable<Movie> sort_all_movies_by_title_ascending()
	{
		return Sort((m1, m2) => m1.title.CompareTo(m2.title));
	}

	public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
	{
		var ratingByStudio = new Dictionary<ProductionStudio, int>
		                     	{
		                     		{ProductionStudio.MGM, 1}, 
									{ProductionStudio.Pixar, 2}, 
									{ProductionStudio.Dreamworks, 3}, 
									{ProductionStudio.Universal, 4}, 
									{ProductionStudio.Disney, 5}
		                     	};

		return Sort((m1, m2) =>
		{
			int studioCompare = ratingByStudio[m1.production_studio].CompareTo(ratingByStudio[m2.production_studio]);
			return studioCompare == 0 ? m1.date_published.CompareTo(m2.date_published) : studioCompare;
		});
	}

	public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
	{
		return Sort((m1, m2) => -1 * m1.date_published.CompareTo(m2.date_published));
	}

	public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
	{
		return Sort((m1, m2) => m1.date_published.CompareTo(m2.date_published));
	}
  }
}