using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Abstractions.Abstracts
{
    public abstract class BaseEntity<TKey>
    {
        // This can easily be modified to be BaseEntity<T> and public T Id to support different key types.
        // Using non-generic integer types for simplicity
        public TKey Id { get; set; }
    }
}
