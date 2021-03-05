using System;

namespace Domain.Entities
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AboutUsDescription { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CoordinateX { get; set; }
        public string CoordinateY { get; set; }
        public bool Active { get; set; } = true;
    }
}
