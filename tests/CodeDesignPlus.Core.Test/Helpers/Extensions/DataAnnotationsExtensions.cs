using CodeDesignPlus.Core.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeDesignPlus.Core.Test.Helpers.Extensions
{
    /// <summary>
    /// Clase que se encarga de proveer metodos de extensión para la validación de los Data Annotations
    /// </summary>
    public static class DataAnnotationsExtensions
    {
        /// <summary>
        /// Metodo de extensión encargado de validar un View Model
        /// </summary>
        /// <typeparam name="TDto">Tipo de objeto a validar</typeparam>
        /// <param name="dto">ViewModel a Validar</param>
        /// <returns>Returna una lista con los resultados de las validaciones</returns>
        public static IList<ValidationResult> Validate<TDto>(this TDto dto) where TDto : IDtoBase
        {
            var results = new List<ValidationResult>();

            var validationContext = new ValidationContext(dto, null, null);

            Validator.TryValidateObject(dto, validationContext, results, true);

            if (dto is IValidatableObject)
                (dto as IValidatableObject).Validate(validationContext);

            return results;
        }
    }
}
