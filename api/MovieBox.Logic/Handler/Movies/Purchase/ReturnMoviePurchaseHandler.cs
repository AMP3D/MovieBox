using MediatR;
using MovieBox.Logic.Command.Movies;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Logic.Handler.Movies.Purchase
{
    public class ReturnMoviePurchaseHandler : IRequestHandler<ReturnMoviePurchaseCommand, int>
    {
        public ReturnMoviePurchaseHandler()
        { }

        public async Task<int> Handle(ReturnMoviePurchaseCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(request.Id);
        }
    }
}