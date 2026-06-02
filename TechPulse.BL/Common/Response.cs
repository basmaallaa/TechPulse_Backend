using System;
using System.Collections.Generic;
using System.Text;

namespace TechPulse.BL.Common
{
    public record Response<T>(T? Data,string? Message = null , bool IsSuccess = true)
    {
    }
}
