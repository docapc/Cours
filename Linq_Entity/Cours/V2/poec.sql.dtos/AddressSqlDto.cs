namespace poec.sql.dtos;

public class AddressSqlDto
{
    public short AddressId { get; set; }
    
    public short UserId { get; set; } 

    public string Label { get; set; }

    public string Address { get; set; }

    /// <summary>
    /// Constructeur par défaut utilisé par EF Core uniquement)
    /// </summary>
    private AddressSqlDto()
    {
    }

    public AddressSqlDto(short addressId, short userId, string label, string address)
    {
        AddressId = addressId;
        UserId = userId;
        Label = label;
        Address = address;
    }
}