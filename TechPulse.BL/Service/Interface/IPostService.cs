using System;
using System.Collections.Generic;
using System.Text;
using TechPulse.BL.Common;
using TechPulse.BL.DTOs;

namespace TechPulse.BL.Service.Interface
{
    public interface IPostService
    {
        Task<Response<IEnumerable<PostResponseDto>>> GetAllPostsAsync();
        Task<Response<PostResponseDto>> CreatePostAsync(CreatePostDto dto);
        Task<Response<bool>> DeletePostAsync(int id);

    }
}
