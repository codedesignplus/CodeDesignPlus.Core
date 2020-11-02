using CodeDesignPlus.Core.Models.Pager;
using CodeDesignPlus.Core.Test.Helpers.Context;
using CodeDesignPlus.Core.Test.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CodeDesignPlus.Core.Test
{
    /// <summary>
    /// Clase que realiza las pruebas unitarias al objeto <see cref="Pager{T}"/>
    /// </summary>
    public class PagerTest
    {
        /// <summary>
        /// Total de elementos usado en las pruebas unitarias
        /// </summary>
        private const int TOTAL_ITEMS = 500;
        /// <summary>
        /// Valor por defecto en la pagina actual
        /// </summary>
        private const int CURRENT_PAGE = 1;
        /// <summary>
        /// Valor por defecto del numero de registros en la pagina actual
        /// </summary>
        private const int PAGE_SIZE = 10;
        /// <summary>
        /// Valor por defecto del numero de paginas a procesar
        /// </summary>
        private const int MAX_PAGES = 10;
        /// <summary>
        /// Gets the data
        /// </summary>
        private readonly List<FakeEntity> data = new List<FakeEntity>();

        /// <summary>
        /// Valida la clase Pager cuando tiene valores por defecto en sus parametros
        /// </summary>
        [Fact]
        public void Constructor_ArgumentsDefault_StateObjectStandard()
        {
            // Act
            var pager = new Pager<FakeEntity>(TOTAL_ITEMS, this.data);

            // Assert
            this.AssertPager(TOTAL_ITEMS, CURRENT_PAGE, PAGE_SIZE, MAX_PAGES, pager, this.data);
        }


        /// <summary>
        /// Valida la clase Pager cuando el parametro current page esta fuera de rango
        /// </summary>
        [Fact]
        public void Constructor_CurrentPageOutOfRange_StateObjectStandard()
        {
            // Act
            var pager = new Pager<FakeEntity>(TOTAL_ITEMS, data, -10);

            // Assert
            this.AssertPager(TOTAL_ITEMS, CURRENT_PAGE, PAGE_SIZE, MAX_PAGES, pager, this.data);
        }

        /// <summary>
        /// Valida la clase Pager cuando el parametro current page esta fuera de rango
        /// </summary>
        [Fact]
        public void Constructor_CurrentPageIsGreaterThanTotalPage_StateObjectStandard()
        {
            // Arrange
            var data = new List<FakeEntity>();
            var currentPages = (int)Math.Ceiling((decimal)TOTAL_ITEMS / 10);

            // Act
            var pager = new Pager<FakeEntity>(TOTAL_ITEMS, data, currentPages + 1);

            // Assert
            this.AssertPager(TOTAL_ITEMS, currentPages, PAGE_SIZE, MAX_PAGES, pager, this.data);
        }

        /// <summary>
        /// Valida la clase Pager cuando el parametro current page esta fuera de rango
        /// </summary>
        [Fact]
        public void Constructor_TotalPagesIsLessThan_StateObjectStandard()
        {
            // Arrange
            var totalItems = 5;

            // Act
            var pager = new Pager<FakeEntity>(totalItems, data);

            // Assert
            this.AssertPager(totalItems, CURRENT_PAGE, PAGE_SIZE, MAX_PAGES, pager, this.data);
        }

        /// <summary>
        /// Valida la paginación cuando esta se encuentra cerca al inicio
        /// </summary>
        [Fact]
        public void Constructor_CurrentPageNearTheStart_StateObjectStandard()
        {
            // Act
            var pager = new Pager<FakeEntity>(TOTAL_ITEMS, data);

            // Assert
            this.AssertPager(TOTAL_ITEMS, CURRENT_PAGE, PAGE_SIZE, MAX_PAGES, pager, this.data);
        }

        /// <summary>
        /// Valida la paginación cuando esta se encuentra cerca al final
        /// </summary>
        [Fact]
        public void Constructor_CurrentPageNearTheEnd_StateObjectStandard()
        {
            // Arrange
            var currentPage = 9;

            // Act
            var pager = new Pager<FakeEntity>(TOTAL_ITEMS, data, currentPage);

            // Assert
            this.AssertPager(TOTAL_ITEMS, currentPage, PAGE_SIZE, MAX_PAGES, pager, this.data);
            Assert.Equal(currentPage - 5, pager.StartPage);
            Assert.Equal(currentPage + 4, pager.EndPage);
        }

        /// <summary>
        /// Valida la paginación cuando esta se encuentra en la mitad
        /// </summary>
        [Fact]
        public void Constructor_CurrentPageNearTheMiddle_StateObjectStandard()
        {
            // Arrange
            var currentPage = 6;

            // Act
            var pager = new Pager<FakeEntity>(TOTAL_ITEMS, data, currentPage);

            // Assert
            this.AssertPager(TOTAL_ITEMS, currentPage, PAGE_SIZE, MAX_PAGES, pager, this.data);
            Assert.Equal(currentPage - 5, pager.StartPage);
            Assert.Equal(currentPage + 4, pager.EndPage);
        }

        /// <summary>
        /// Valida la paginación a partir de un metodo de extensión para EF Core
        /// </summary>
        [Fact]
        public async Task Pager_ArgumentsDefault_StateObjectStandardWithDataDB()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FakeContext>()
                .UseInMemoryDatabase(databaseName: "FakeDbMemory")
                .Options;

            var fakeContext = new FakeContext(options);
            var entities = new List<FakeEntity>();

            for (int i = 0; i < 500; i++)
            {
                entities.Add(new FakeEntity()
                {
                    Name = $"Fake - {i}",
                    State = true,
                    IdUserCreator = Guid.NewGuid().ToString("D"),
                    DateCreated = DateTime.Now,
                });
            }
            await fakeContext.FakeEntity.AddRangeAsync(entities);
            await fakeContext.SaveChangesAsync();

            // Act
            var pager = await fakeContext.FakeEntity.Where(x => x.State).ToPageAsync(CURRENT_PAGE, PAGE_SIZE);

            // Assert
            this.AssertPager(TOTAL_ITEMS, CURRENT_PAGE, PAGE_SIZE, MAX_PAGES, pager, entities);
        }

        /// <summary>
        /// Metodo encargado de validar el estado del objeto pager
        /// </summary>
        /// <param name="totalItems">Total de elementos a validar</param>
        /// <param name="currentPage">Pagina actual</param>
        /// <param name="pageSize">Numero de registros en la pagina</param>
        /// <param name="maxPages">Numero de paginas a retornar</param>
        /// <param name="pager">Objeto pager a validar</param>
        private void AssertPager(int totalItems, int currentPage, int pageSize, int maxPages, Pager<FakeEntity> pager, List<FakeEntity> data)
        {
            var startIndex = (currentPage - 1) * pageSize;
            var endIndex = Math.Min(startIndex + pageSize - 1, totalItems - 1);
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);

            maxPages = totalPages <= maxPages ? maxPages = totalPages : maxPages;

            Assert.Equal(totalItems, pager.TotalItems);
            Assert.Equal(currentPage, pager.CurrentPage);
            Assert.Equal(pageSize, pager.PageSize);
            Assert.Equal(totalPages, pager.TotalPages);
            Assert.Equal(pager.Pages.Min(), pager.StartPage);
            Assert.Equal(pager.Pages.Max(), pager.EndPage);
            Assert.Equal(maxPages, pager.Pages.Count());
            Assert.Equal(startIndex, pager.StartIndex);
            Assert.Equal(endIndex, pager.EndIndex);

            foreach (var item in pager.Data)
            {
                var exist = data.Any(x => x.Id == item.Id);

                Assert.True(exist);
            }
        }
    }
}
