using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("MissionOutput")]
    public class MissionOutput
    {
        public int Id { get; set; }
        public string RawString { get; set; }
        public decimal ExploredPercentage { get; set; }
        public decimal SuccessPercentage { get; set; }
        public int InputId { get; set; }
        public MissionInput Input { get; set; }
    }
}
