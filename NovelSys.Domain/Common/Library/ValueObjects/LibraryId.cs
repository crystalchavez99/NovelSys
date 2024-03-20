using NovelSys.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSys.Domain.Common.Library.ValueObjects
{
    public sealed class LibraryId : ValueObject
    {
        public Guid Value { get; }

        private LibraryId(Guid value) { 
            Value = value;
        }

        public static LibraryId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
