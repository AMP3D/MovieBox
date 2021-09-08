using MediatR;
using MovieBox.Logic.Command.Movies;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Logic.Handler.Movies.Rental
{
    public class ReturnMovieRentalHandler : IRequestHandler<ReturnMovieRentalCommand, int>
    {
        public ReturnMovieRentalHandler()
        { }

        public async Task<int> Handle(ReturnMovieRentalCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(request.Id);
        }
    }
}