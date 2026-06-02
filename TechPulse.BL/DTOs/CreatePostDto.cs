using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TechPulse.DAL.Enums;

namespace TechPulse.BL.DTOs
{
    public class CreatePostDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(5, ErrorMessage = "Title must be at least 5 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required")]
        public Category Category { get; set; }

        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinLength(20, ErrorMessage = "Description must be at least 20 characters")]
        public string Description { get; set; } = string.Empty;
    }
}
