using NovelSys.Domain.Common.Library.ValueObjects;
using NovelSys.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSys.Domain.Common.Library.Entities
{
    public sealed class LibrarySection : Entity<LibrarySectionId>
    {
        private readonly List<LibraryItem> _items = new();
        public string Name { get; }
        public string Description { get; }

        public IReadOnlyList<LibraryItem> Items => _items.AsReadOnly();

        private LibrarySection(
            LibrarySectionId librarySectionId,
            string name,
            string description)
            : base(librarySectionId)
        {
            Name = name;
            Description = description;
        }

        private static LibrarySection Create(
            string name,
            string descripton)
        {
            return new(
                LibrarySectionId.CreateUnique(),
                name,
                descripton);
        }
    }
}
