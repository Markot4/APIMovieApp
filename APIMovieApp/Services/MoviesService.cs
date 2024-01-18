using APIMovieApp.Data;

namespace APIMovieApp.Services
{
    public class MoviesService
    {
        private AppDbContext _context;
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }
        public void AddMovie(MovieVM movie)
        {
            var newMovie = new Movie()
            {
                Id = movie.Id,
                Name = movie.Name,
                Year = movie.Year,
                Genre = movie.Genre,
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }
        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }
        public Movie UpdateMovieById(int id, MovieVM movieVM)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                movie.Id = movieVM.Id;
                movie.Name = movieVM.Name;
                movie.Year = movieVM.Year;
                movie.Genre = movieVM.Genre;
                _context.SaveChanges();
            }
            return movie;
        }
        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
