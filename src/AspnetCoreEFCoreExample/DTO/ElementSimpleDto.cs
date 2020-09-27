using System.Collections.Generic;

namespace AspnetCoreEFCoreExample.DTO
{
    public class ElementSimpleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserBasicInfosDto User { get; set; }
        public int CategoryCount { get; set; }
        public IEnumerable<CategoryBasicInfosDto> Categories { get; set; }
        //public string Category { get; set; }
    }
}
