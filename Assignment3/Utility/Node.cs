using System.Runtime.Serialization;

namespace Assignment3
{
    [DataContract]
    public class Node
    {
        [DataMember]
        public User Value { get; set; }
        [DataMember]
        public Node Next { get; set; }

        public Node(User value)
        {
            Value = value;
            Next = null;
        }
    }
}
