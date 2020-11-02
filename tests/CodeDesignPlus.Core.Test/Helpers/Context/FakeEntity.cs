using CodeDesignPlus.Core.Abstractions;
using System;

namespace CodeDesignPlus.Core.Test.Helpers.Context
{
    /// <summary>
    /// Entidad fake que permitira validar el modelo de paginación
    /// </summary>
    public class FakeEntity : IEntityLong<string>
    {
        /// <summary>
        /// Id del registro
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Fake Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Estado del registro
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// Id del usuario que creo el registro
        /// </summary>
        public string IdUserCreator { get; set; }
        /// <summary>
        /// Fecha de creación del registro
        /// </summary>
        public DateTime DateCreated { get; set; }
    }
}
