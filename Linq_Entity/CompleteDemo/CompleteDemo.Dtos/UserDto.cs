using System.Runtime.Serialization;

namespace CompleteDemo.Dtos
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public string Name { get; set; }
    }
}
