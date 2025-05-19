﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Sharing
{
    public class BookParams
    {
        //string? sort,int? categoryId, int pageSize, int pageNumber

        public string? Sort { get; set; }
        public string Search { get; set; }

        public int? CategoryId { get; set; }
        public int MaxPageSize { get; set; } = 6;
        private int _pageSize = 3;

        public int PageSize
        {
            get { return _pageSize = 3; }
            set { _pageSize = value>MaxPageSize?MaxPageSize:value; }
        }

        public int PageNumber { get; set; } = 1;

    }
}
