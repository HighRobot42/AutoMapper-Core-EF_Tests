using System.Collections.Generic;

namespace AspnetCoreEFCoreExample.Models
{
    public class User
    {
        protected User()
        {

        }
        public User(int id, string name)
        {
            Id = id;
            Name = name;
            ElementMembers = new List<ElementMember>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ElementMember> ElementMembers { get; set; }
    }
}
