using System;

namespace TUSA.Core
{
    public interface IApplicationUser
    {
        int UserId { get; }
        int StaffId { get; }
    }
}