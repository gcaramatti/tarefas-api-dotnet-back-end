using Microsoft.EntityFrameworkCore;

namespace InspecaoAPI.DataClasses
{
    public class TarefasData : DbContext
    {
        public TarefasData(DbContextOptions<TarefasData> opcoes) : base(opcoes) { }
        public DbSet<TarefaModel> Tarefa { get; set; }
        public DbSet<TipoTarefaModel> TipoTarefa { get; set; }
        public DbSet<StatusModel> StatusTarefa { get; set; }
    }
}
