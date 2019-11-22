using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace GradProject.Services
{
    public interface IUserService
    {
        ClaimsPrincipal User { get; }
        string CurrentUserId { get; }
    }
}

