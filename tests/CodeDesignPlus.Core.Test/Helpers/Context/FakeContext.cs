using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CodeDesignPlus.Core.Test.Helpers.Context
{
    /// <summary>
    /// Contexto de base de datos fake para validar la paginación
    /// </summary>
    public class FakeContext : DbContext
    {
        /// <summary>
        /// Crea una nueva instancia de FakeContext
        /// </summary>
        protected FakeContext()
        {
        }

        /// <summary>
        /// Crea una nueva instancia de FakeContext
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public FakeContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the fake entity
        /// </summary>
        public DbSet<FakeEntity> FakeEntity { get; set; }
    }
}
