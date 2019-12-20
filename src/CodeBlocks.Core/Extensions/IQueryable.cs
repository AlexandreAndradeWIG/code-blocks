using CodeBlocks.Core.Model;
using System;
using System.Linq;

namespace CodeBlocks.Core.Extensions
{
    public static class IQueryable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            page = (page > 0) ? page : 1;
            pageSize = (pageSize > 0) ? pageSize : 20;

            var result = new PagedResult<T>
            {
                Page = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Data = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }


}
