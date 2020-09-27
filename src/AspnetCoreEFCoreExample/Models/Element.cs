using System.Collections.Generic;

namespace AspnetCoreEFCoreExample.Models
{
    public class Element
    {
        protected Element()
        {
            Categories = new List<Category>();
            ElementMembers = new List<ElementMember>();
        }
        public Element(int id, string name)
        {
            Id = id;
            Name = name;
            //ElementMembers = new List<ElementMember>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ElementMember> ElementMembers { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
