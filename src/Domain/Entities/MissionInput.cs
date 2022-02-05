using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("MissionInput")]
    public class MissionInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RawString { get; set; }
        public int? OutputId { get; set; }
        public MissionOutput Output { get; set; }
    }
}
