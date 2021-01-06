using System;

namespace E_Commers.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        DateTime OpenAccountDate { get; set; }
    }
}
