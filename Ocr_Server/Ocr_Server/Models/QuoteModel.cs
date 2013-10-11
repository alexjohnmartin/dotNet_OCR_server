using System;

namespace Ocr_Server.Models
{
    public class QuoteModel
    {
        public Guid QuoteId { get; set; }
        public decimal Price { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}