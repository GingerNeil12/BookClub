using System;
using System.Collections.Generic;
using MediatR;

namespace BookClub.EventBus.Commands.Create
{
    public class CreateBook : IRequest<int>
    {
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string ISBN { get; set; }
        public bool NonFiction { get; set; }
        public bool HardBack { get; set; }
        public int GenreId { get; set; }
        public int? PageCount { get; set; }
        public int? Edition { get; set; }
        public DateTime? PublishedOn { get; set; }
        public string Author { get; set; }
        public IEnumerable<string> CoAuthors { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
