using NovelSys.Domain.Common.Library.ValueObjects;
using NovelSys.Domain.Common.Models;


namespace NovelSys.Domain.Common.Library.Entities
{
    public sealed class LibraryItem : Entity<LibraryItemId>
    {

        public string Name { get; }
        public string Summary { get; }

        public string Genre { get; }


        private LibraryItem(LibraryItemId libraryItemId, string name, string summary, string genre) : base(libraryItemId)
        {
            Name = name;
            Summary = summary;
            Genre = genre;
        }

       /* public static LibraryItem Create(string name, string summary, string genre)
        {
            return new LibraryItem(LibraryItemId.CreateUnique(), name, summary, genre);
        }*/

    }
}
