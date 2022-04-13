using System.ComponentModel.DataAnnotations;

namespace InspecaoAPI
{
    public class StatusModel
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string OpcaoStatus { get; set; } = String.Empty;
    }
}
