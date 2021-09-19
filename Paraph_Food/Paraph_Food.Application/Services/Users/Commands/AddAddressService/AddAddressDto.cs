namespace Paraph_Food.Application.Services.Users.Commands.AddAddressService
{
    public class AddAddressDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsDefault { get; set; }
    }
}
