using CodeDesignPlus.Core.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace CodeDesignPlus.Core.Models.Pager
{
    /// <summary>
    /// Modelo que permitira obtener los datos de la petición para paginar los datos
    /// </summary>
    public class Parameters: IDtoBase
    {
        /// <summary>
        /// Pagina actual
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "The {0} field not is valid.")]
        public int CurrentPage { get; set; }
        /// <summary>
        /// Numero de registros en la pagina
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "The {0} field not is valid.")]
        public int PageSize { get; set; }
        /// <summary>
        /// Numero de paginas maximas
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "The {0} field not is valid.")]
        public int MaxPage { get; set; }
    }
}
