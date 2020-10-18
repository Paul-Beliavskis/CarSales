using System.ComponentModel.DataAnnotations;
using CarSales.VehicleManagement.Domain.Enums;

namespace CarSales.VehicleManagement.Domain.Entities
{
    public abstract class VehicleBase
    {
        [Key]
        public int Id { get; set; }

        public int VehicleId { get; set; }

        //This is protected because only concrete classes should set this
        public VehicleType VehicleType { get; set; }

        public double Price { get; set; }

        public Vehicle Vehicle { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }
    }
}
