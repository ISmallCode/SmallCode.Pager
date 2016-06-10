using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCode.Pager
{
    public interface IPageList
    {
        int PageCount { get; set; }

        int TotalItemCount { get; set; }

        int PageNumber { get; set; }

        int PageSize { get; set; }
    }
}
