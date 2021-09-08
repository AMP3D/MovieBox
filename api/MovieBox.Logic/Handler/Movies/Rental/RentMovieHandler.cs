using MediatR;
using MovieBox.Logic.Command.Movies;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Logic.Handler.Movies.Rental
{
    public class RentMovieHandler : IRequestHandler<RentMovieCommand, int>
    {
        public RentMovieHandler()
        { }

        public async Task<int> Handle(RentMovieCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(request.Id);
        }
    }
}