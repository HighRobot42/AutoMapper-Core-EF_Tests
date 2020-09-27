using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreEFCoreExample.Models
{
    public class ElementMember
    {
        public ElementMember()
        {

        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ElementId { get; set; }

        public string LinkDescription { get; set; }

        [ForeignKey(nameof(ElementId))]
        public Element Element { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
