using System.ComponentModel.DataAnnotations;

namespace InspecaoAPI
{
    public class TipoTarefaModel
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Nome { get; set; } = String.Empty;
    }
}
