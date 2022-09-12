using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoPadraoNetCore.Domain.ViewModel
{
    public class PagedCollectionViewModel<T> where T : class
    {
        public PagedCollectionViewModel()
        {
        }

        public PagedCollectionViewModel(int totalItems, IEnumerable<T> Items, FilterBaseViewModel filter)
        {
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)filter.PageSize);

            // ensure current page isn't out of range
            if (filter.Page < 1)
            {
                filter.Page = 1;
            }
            else if (filter.Page > totalPages)
            {
                filter.Page = totalPages;
            }

            int startPage, endPage;
            if (totalPages <= filter.MaxPages)
            {
                // total pages less than max so show all pages
                startPage = 1;
                endPage = totalPages;
            }
            else
            {
                // total pages more than max so calculate start and end pages
                var maxPagesBeforePage = (int)Math.Floor((decimal)filter.MaxPages / (decimal)2);
                var maxPagesAfterPage = (int)Math.Ceiling((decimal)filter.MaxPages / (decimal)2) - 1;
                if (filter.Page <= maxPagesBeforePage)
                {
                    // current page near the start
                    startPage = 1;
                    endPage = filter.MaxPages;
                }
                else if (filter.Page + maxPagesAfterPage >= totalPages)
                {
                    // current page near the end
                    startPage = totalPages - filter.MaxPages + 1;
                    endPage = totalPages;
                }
                else
                {
                    // current page somewhere in the middle
                    startPage = filter.Page - maxPagesBeforePage;
                    endPage = filter.Page + maxPagesAfterPage;
                }
            }

            // calculate start and end item indexes
            var startIndex = (filter.Page - 1) * filter.PageSize;
            var endIndex = Math.Min(startIndex + filter.PageSize - 1, totalItems - 1);

            // create an array of pages that can be looped over
            var pages = Enumerable.Range(startPage, (endPage + 1) - startPage);

            // update object instance with all pager properties required by the view
            TotalItems = totalItems;
            CurrentPage = filter.Page;
            PageSize = filter.PageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            StartIndex = startIndex;
            EndIndex = endIndex;
            Pages = pages;
            this.Items = Items;
        }
        public IEnumerable<T> Items { get; private set; }
        public IEnumerable<int> Pages { get; private set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int StartIndex { get; private set; }
        public int EndIndex { get; private set; }
        public int TotalPages { get; private set; }
    }
}
