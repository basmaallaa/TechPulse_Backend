using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TechPulse.BL.Common;
using TechPulse.BL.DTOs;
using TechPulse.BL.Helper;
using TechPulse.BL.Service.Interface;
using TechPulse.DAL.Models;
using TechPulse.DAL.Repository;

namespace TechPulse.BL.Service.Implementation
{
    public class PostService : IPostService
    {
        private readonly IPostRepo _postRepo;
        private readonly IMapper _mapper;


        public PostService(IPostRepo postRepo, IMapper mapper)
        {
            _postRepo = postRepo;
            _mapper = mapper;
        }
        public async Task<Response<PostResponseDto>> CreatePostAsync(CreatePostDto dto)
        {
            try
            {
                var post = _mapper.Map<Post>(dto);
                post.PublishedAt = DateTime.UtcNow;

                if (dto.Image != null)
                {
                    post.ImageUrl = await FileHelper.UploadFileAsync(dto.Image);
                }
                var savedPost = await _postRepo.AddAsync(post);
                var result = _mapper.Map<PostResponseDto>(savedPost);

                return new Response<PostResponseDto>(
                    result,
                    "Post created successfully",
                    true
                );

            }
            catch (Exception ex) 
            {
                return new Response<PostResponseDto>(
                    null,
                    $"An error occurred while adding the post: {ex.Message}",
                    false
                );
            }

        }

        public async Task<Response<IEnumerable<PostResponseDto>>> GetAllPostsAsync()
        {
            try
            {
                var posts = await _postRepo.GetAllAsync();
                var result = _mapper.Map<IEnumerable<PostResponseDto>>(posts);
                return new Response<IEnumerable<PostResponseDto>>(
                    result,
                    "Posts retrieved successfully",
                    true
                );
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<PostResponseDto>>(
                    null,
                    $"An error occurred while retrieving posts: {ex.Message}",
                    false
                );
            }
        }
        public async Task<Response<bool>> DeletePostAsync(int id)
        {
            try
            {
                var post = await _postRepo.GetByIdAsync(id);

                if (post == null)
                    return new Response<bool>(false, "Post not found.", false);


                await _postRepo.DeleteAsync(id);

                return new Response<bool>(true, "Post deleted successfully.", true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(
                    false,
                    $"An error occurred while deleting the post: {ex.Message}",
                    false
                );
            }
        }
    }
}

