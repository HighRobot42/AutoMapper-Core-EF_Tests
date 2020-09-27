using System.Collections.Generic;

namespace AspnetCoreEFCoreExample.DTO
{
    public class ElementDto<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int? UserId { get; set; }

        //public T User { get; set; }
        public IEnumerable<T> Categories { get; set; }
    }
}
