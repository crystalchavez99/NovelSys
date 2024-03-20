using NovelSys.Domain.Common.Models;


namespace NovelSys.Domain.Common.Library.ValueObjects
{
    public class LibraryItemId : ValueObject
    {
        public Guid Value { get; }

        private LibraryItemId(Guid value)
        {
            Value = value;
        }

        public static LibraryItemId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
