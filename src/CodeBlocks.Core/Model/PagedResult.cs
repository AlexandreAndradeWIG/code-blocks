using System;
using System.Collections.Generic;

namespace CodeBlocks.Core.Model
{
    public class PagedResult<T> : Result where T : class
    {
        public IList<T> Data { get; set; }

        /// <summary>
        /// Current Page number.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Number of Pages.
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Number os item per Page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Total count of data items.
        /// </summary>
        public long RowCount { get; set; }


        public long FirstRowOnPage
        {
            get { return (Page - 1) * PageSize + 1; }
        }

        public long LastRowOnPage
        {
            get { return Math.Min(Page * PageSize, RowCount); }
        }

        public PagedResult() : base()
        {
            Data = new List<T>();
        }
        public PagedResult(IList<T> value) : base()
        {
            Data = value;
        }
        public PagedResult(bool success, List<ResultMessage> resultMessages = null) : base(success, resultMessages)
        {
            Data = new List<T>();
        }
        public PagedResult(bool success, IList<T> value, List<ResultMessage> resultMessages = null, List<ValidationError> validationErrors = null) : base(success, resultMessages, validationErrors)
        {
            Data = value;
        }
    }
}
