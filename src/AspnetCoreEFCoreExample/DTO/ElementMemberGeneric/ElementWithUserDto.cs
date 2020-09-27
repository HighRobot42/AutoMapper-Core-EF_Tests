using System.Collections.Generic;

namespace AspnetCoreEFCoreExample.DTO.ElementMemberGeneric
{
    public class ElementWithUserDto<TUserDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryBasicInfosDto> Categories { get; set; }
        public ElementMemberDto<TUserDto> ElementUser { get; set; }
    }
}
