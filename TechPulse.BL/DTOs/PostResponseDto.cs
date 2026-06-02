using System;
using System.Collections.Generic;
using System.Text;
using TechPulse.DAL.Enums;

namespace TechPulse.BL.DTOs
{
    public class PostResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
