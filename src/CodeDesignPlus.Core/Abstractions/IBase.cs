using System;

namespace CodeDesignPlus.Core.Abstractions
{
    /// <summary>
    /// Define la estructura base para las entidades y dto y tipos genericos
    /// </summary>
    public interface IBase { }

    /// <summary>
    /// Define la estructura base para las entidades y dto
    /// </summary>
    /// <typeparam name="TKey">Tipo de dato que identificara el registro</typeparam>
    /// <typeparam name="TUserKey">Tipo de datos que identificara el usuario</typeparam>
    public interface IBase<TKey, TUserKey>: IBase
    {
        /// <summary>
        /// Id del registro
        /// </summary>
        public TKey Id { get; set; }
        /// <summary>
        /// Estado del registro
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// Id del usuario que creo el registro
        /// </summary>
        public TUserKey IdUserCreator { get; set; }
        /// <summary>
        /// Fecha de creación del registro
        /// </summary>
        public DateTime DateCreated { get; set; }
    }
}
