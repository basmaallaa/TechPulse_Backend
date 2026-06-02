using System;
using System.Collections.Generic;
using System.Text;
using TechPulse.DAL.Models;

namespace TechPulse.DAL.Repository
{
    public interface IPostRepo
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> AddAsync (Post post);
        Task<Post?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
