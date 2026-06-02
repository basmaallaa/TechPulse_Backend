using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TechPulse.DAL.Enums;

namespace TechPulse.DAL.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Category Category { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; } = string.Empty;

        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
    }
}
