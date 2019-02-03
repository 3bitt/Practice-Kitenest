using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitenest.Models.Interfaces
{
    public interface IPagination
    {
        int CurrentPage { get; }

        int TotalPages { get; }
    }
}
