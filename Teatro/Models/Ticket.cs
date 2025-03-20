using Microsoft.AspNetCore.Mvc;

namespace Teatro.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int PlayId { get; set; }
        public Play Play { get; set; }
        public string UserId { get; set; } // Връзка с таблицата AspNetUsers
        public ApplicationUser User { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
