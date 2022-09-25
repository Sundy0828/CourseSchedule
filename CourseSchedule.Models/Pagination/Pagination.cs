using System;

namespace CourseSchedule.Models.Pagination
{
    public abstract class Pagination
    {
        const int maxPageSize = 1000;
        public int PageNumber { get; private set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value > maxPageSize ? maxPageSize : value;
            }
        }
    }
}

