using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TechPulse.BL.DTOs;
using TechPulse.DAL.Models;

namespace TechPulse.BL.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile() 
        {
            CreateMap<Post, PostResponseDto>();
            CreateMap<CreatePostDto, Post>();
        }
    }
}
