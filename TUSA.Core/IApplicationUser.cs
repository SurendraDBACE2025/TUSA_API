using System;

namespace TUSA.Core
{
    public interface IApplicationUser
    {
        string  UserId { get; }
        string StaffId { get; }
    }
}