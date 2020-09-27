namespace AspnetCoreEFCoreExample.DTO.ElementMemberGeneric
{
    public class ElementMemberDto<TUser>
    {
        public string LinkDescription { get; set; }
        public TUser User { get; set; }
    }
}
