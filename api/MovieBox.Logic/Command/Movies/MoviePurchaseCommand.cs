using MediatR;

namespace MovieBox.Logic.Command.Movies
{
    public record PurchaseMovieCommand(int Id, string UserName) : IRequest<int>;

    public record ReturnMoviePurchaseCommand(int Id, string UserName) : IRequest<int>;
}