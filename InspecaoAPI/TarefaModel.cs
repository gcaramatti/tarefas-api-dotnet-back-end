using System.ComponentModel.DataAnnotations;

namespace InspecaoAPI
{
    public class TarefaModel
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string Name { get; set; }
        [StringLength(30)]
        public string Status { get; set; } = String.Empty;
        [StringLength(255)]
        public string Descricao { get; set; } = String.Empty;
        public int TipoTarefaId { get; set; }
        public TipoTarefaModel? tipoTarefa { get; set; }
    }
}
