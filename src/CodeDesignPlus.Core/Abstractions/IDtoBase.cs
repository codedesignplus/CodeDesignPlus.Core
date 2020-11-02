namespace CodeDesignPlus.Core.Abstractions
{
    /// <summary>
    /// Definición para las entidades base y restricción para tipos genericos
    /// </summary>
    public interface IDtoBase : IBase { }

    /// <summary>
    /// Definición para las entidades base
    /// </summary>
    /// <typeparam name="TKey">Tipo de dato que identificara el registro</typeparam>
    /// <typeparam name="TUserKey">Tipo de datos que identificara el usuario</typeparam>
    public interface IDtoBase<TKey, TUserKey> : IBase<TKey, TUserKey>, IDtoBase
    {

    }
}
