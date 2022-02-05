using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("MissionOutput", Schema = "Space")]
    public class MissionOutput
    {
        public Guid Id { get; set; }
        public string RawString { get; set; }
        public decimal ExploredPercentage { get; set; }
        public decimal SuccessPercentage { get; set; }
        public Guid? InputId { get; set; }
        public MissionInput Input { get; set; }
    }
}
