using System;

namespace FilmManagement.Core.Models.Base
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }

        public int PageCount
        {
            get
            {
                var pageCount = (double)RowCount / PageSize;
                return (int)Math.Ceiling(pageCount) >= 0 ? (int)Math.Ceiling(pageCount) : 0;
            }
            set { PageCount = value; }
        }
        public int PageSize { get; set; }

        public int RowCount { get; set; }

        public int FirstRowOnPage
        {
            get
            {
                return (CurrentPage - 1) * PageSize + 1;
            }
        }
        public int LastRowOnPage
        {
            get
            {
                return Math.Min(CurrentPage * PageSize, RowCount);
            }
        }

        public Object Footer { get; set; }
    }
}
