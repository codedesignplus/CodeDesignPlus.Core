using CodeDesignPlus.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeDesignPlus.Core.Models.Pager
{
    /// <summary>
    /// Pagina los datos de un IQueryable
    /// </summary>
    /// <remarks>https://jasonwatmore.com/post/2018/10/17/c-pure-pagination-logic-in-c-aspnet</remarks>
    /// <typeparam name="T">Tipo de datos a retornar en el objeto</typeparam>
    public class Pager<T> where T : IBase
    {
        /// <summary>
        /// Gets the total items
        /// </summary>
        public int TotalItems { get; private set; }
        /// <summary>
        /// Gets the current page
        /// </summary>
        public int CurrentPage { get; private set; }
        /// <summary>
        /// Gets the page size
        /// </summary>
        public int PageSize { get; private set; }
        /// <summary>
        /// Gets the total pages
        /// </summary>
        public int TotalPages { get; private set; }
        /// <summary>
        /// Gets the start page
        /// </summary>
        public int StartPage { get; private set; }
        /// <summary>
        /// Gets the end page
        /// </summary>
        public int EndPage { get; private set; }
        /// <summary>
        /// Gets the start index
        /// </summary>
        public int StartIndex { get; private set; }
        /// <summary>
        /// Gets the end index
        /// </summary>
        public int EndIndex { get; private set; }
        /// <summary>
        /// Gets the pages
        /// </summary>
        public IEnumerable<int> Pages { get; private set; }
        /// <summary>
        /// Gets the data
        /// </summary>
        public List<T> Data { get; private set; }

        /// <summary>
        /// Crea una nueva instancia de Pager
        /// </summary>
        /// <param name="totalItems">Asigna el total de elemento a retornar</param>
        /// <param name="currentPage">Pagina actual</param>
        /// <param name="pageSize">Numero de registros por pagina</param>
        /// <param name="maxPages">Numero de paginas</param>
        public Pager(int totalItems, List<T> data, int currentPage = 1, int pageSize = 10, int maxPages = 10)
        {
            // calculate total pages
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);

            // ensure current page isn't out of range
            if (currentPage < 1)
                currentPage = 1;
            else if (currentPage > totalPages)
                currentPage = totalPages;

            int startPage, endPage;
            if (totalPages <= maxPages)
            {
                // total pages less than max so show all pages
                startPage = 1;
                endPage = totalPages;
            }
            else
            {
                // total pages more than max so calculate start and end pages
                var maxPagesBeforeCurrentPage = (int)Math.Floor((decimal)maxPages / (decimal)2);
                var maxPagesAfterCurrentPage = (int)Math.Ceiling((decimal)maxPages / (decimal)2) - 1;
                if (currentPage <= maxPagesBeforeCurrentPage)
                {
                    // current page near the start
                    startPage = 1;
                    endPage = maxPages;
                }
                else if (currentPage + maxPagesAfterCurrentPage >= totalPages)
                {
                    // current page near the end
                    startPage = totalPages - maxPages + 1;
                    endPage = totalPages;
                }
                else
                {
                    // current page somewhere in the middle
                    startPage = currentPage - maxPagesBeforeCurrentPage;
                    endPage = currentPage + maxPagesAfterCurrentPage;
                }
            }

            // calculate start and end item indexes
            var startIndex = (currentPage - 1) * pageSize;
            var endIndex = Math.Min(startIndex + pageSize - 1, totalItems - 1);

            // create an array of pages that can be looped over
            var pages = Enumerable.Range(startPage, (endPage + 1) - startPage);

            // update object instance with all pager properties required by the view
            this.TotalItems = totalItems;
            this.CurrentPage = currentPage;
            this.PageSize = pageSize;
            this.TotalPages = totalPages;
            this.StartPage = startPage;
            this.EndPage = endPage;
            this.StartIndex = startIndex;
            this.EndIndex = endIndex;
            this.Pages = pages;
            this.Data = data;
        }
    }
}
