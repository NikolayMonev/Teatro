using System;
using System.ComponentModel.DataAnnotations;

namespace Teatro.Models
{
    public class Play
    {
        public int Id { get; set; }  // Идентификатор на представление

        [Required]
        public string Title { get; set; }  // Заглавие на представление

        [Required]
        public string Description { get; set; }  // Описание на представление

        public DateTime Date { get; set; }  // Дата на представление

        public int Duration { get; set; }  // Продължителност на постановката

        public int TicketsAvailable { get; set; }  // Брой налични билети
        public string Director { get; set; }
        public string Location { get; set; }
    }
}
