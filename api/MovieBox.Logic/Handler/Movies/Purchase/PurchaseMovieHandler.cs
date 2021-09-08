using MediatR;
using MovieBox.Logic.Command.Movies;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Logic.Handler.Movies.Purchase
{
    public class PurchaseMovieHandler : IRequestHandler<PurchaseMovieCommand, int>
    {
        public PurchaseMovieHandler()
        { }

        public async Task<int> Handle(PurchaseMovieCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(request.Id);
        }
    }
}