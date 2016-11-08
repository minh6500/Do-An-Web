using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhKienMayTinh.Models
{
    public static class SanPhamKhac
    {
        public static IEnumerable<T> LaySanPhamNgauNhien<T>(this IEnumerable<T> source, Int32 count)
        {
            return source.OrderBy(n => Guid.NewGuid()).Take(count);
        }

    }
}