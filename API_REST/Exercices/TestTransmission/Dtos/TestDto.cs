namespace Dtos
{
    public class TestDto
    {
        //[jsonproperty("nomenjson")]
        public short UserId { get; set; }

        public string? UserName { get; set; }

        public string? Login { get; set; }

        public DateTime? Birthday { get; set; }
    }
}