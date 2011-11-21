using System;

namespace prep.collections
{
  public class Movie
  {
	public string title { get; set; }
	public ProductionStudio production_studio { get; set; }
	public Genre genre { get; set; }
	public int rating { get; set; }
	public DateTime date_published { get; set; }

	//public Movie Clone()
	//{
	//    return new Movie() {title = title, production_studio = production_studio, genre = genre, rating = rating, date_published = date_published};
	//}
  }
}