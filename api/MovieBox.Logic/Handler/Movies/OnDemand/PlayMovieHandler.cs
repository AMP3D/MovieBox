using MediatR;
using MovieBox.Logic.Command.Movies;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Logic.Handler.Movies.OnDemand
{
    public class PlayMovieHandler : IRequestHandler<PlayMovieCommand, int>
    {
        public PlayMovieHandler()
        { }

        public async Task<int> Handle(PlayMovieCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(request.Id);
        }
    }
}