using CarManagementApplication.Data.Entities;

namespace CarManagementApplication.Services.Dtos
{
    public class ResponseCarDTO(Car carEntity)
    {
        public long Id { get; } = carEntity.Id;
        public string Make { get; } = carEntity.Make;
        public string Model { get; } = carEntity.Model;
        public int ProductionYear { get; } = carEntity.ProductionYear;
        public string LicensePlate { get; } = carEntity.LicensePlate;
        public IEnumerable<ResponseGarageDTO> Garages { get; } = carEntity.Garages.Select(x => new ResponseGarageDTO(x));
    }
}