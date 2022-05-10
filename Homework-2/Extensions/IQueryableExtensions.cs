using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Extensions
{
    public static class IQueryableExtensions
    {
        public static async Task<List<T>> ToListAsync<T> (this IQueryable<T> obj) => await Task.Run(() => obj.ToList());
    }
}