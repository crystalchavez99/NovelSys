using NovelSys.Domain.Common.Library.Entities;
using NovelSys.Domain.Common.Library.ValueObjects;
using NovelSys.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSys.Domain.Common.Library
{
    public sealed class Library : AggregateRoot<LibraryId>
    {
        private readonly List<LibrarySection> _sections = new();

        public string Name { get; }

        public string Location { get; }

        public IReadOnlyList<LibrarySection> Sections => _sections.AsReadOnly();

        private Library(
            LibraryId libraryId,
            string name, 
            string location,
            List<LibrarySection> sections
            ) : base(libraryId)
        {
            Name = name;
            Location = location;
            _sections = sections;
        }

        private static Library Create(
            string name,
            string location,
            List<LibrarySection>? sections = null
            )
        {
            return new Library(
                LibraryId.CreateUnique(),
                name,
                location,
                sections ?? new());
        }
    }
}
