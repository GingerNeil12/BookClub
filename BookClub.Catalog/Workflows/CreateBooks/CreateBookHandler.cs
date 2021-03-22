using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookClub.Catalog.DataAccess;
using BookClub.Catalog.Strategies;
using BookClub.EventBus.Commands.Create;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookClub.Catalog.Workflows.CreateBooks
{
    class CreateBookHandler : IRequestHandler<CreateBook, int>
    {
        private readonly ICatalogDbContext _context;
        private readonly IBookAuthorStrategy _bookAuthorStrategy;
        private readonly ITagStrategy _tagStrategy;
        private readonly IMediator _mediator;
        private readonly ILogger<CreateBookHandler> _logger;

        public CreateBookHandler
        (
            ICatalogDbContext context,
            IBookAuthorStrategy bookAuthorStrategy,
            ITagStrategy tagStrategy,
            IMediator mediator,
            ILogger<CreateBookHandler> logger
        )
        {
            _context = context;
            _bookAuthorStrategy = bookAuthorStrategy;
            _tagStrategy = tagStrategy;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<int> Handle
        (
            CreateBook request,
            CancellationToken cancellationToken
        )
        {
            var genre = _context.Genres
                .Where(x => x.Id == request.GenreId)
                .FirstOrDefault();

            if (genre is null)
            {
                // throw
            }

            var publisher = _context.Publishers
                .Where(x => x.Id == request.PublisherId)
                .FirstOrDefault();

            if (publisher is null)
            {
                // throw
            }

            // convert list of authors to list of Author objects
            // convert list of tags to list of Tag objects

            return 1;
        }
    }
}
