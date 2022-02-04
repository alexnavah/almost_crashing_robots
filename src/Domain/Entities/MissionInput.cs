﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("MissionInput", Schema = "Space")]
    public class MissionInput
    {
        public Guid Id { get; set; }
        public string RawValue { get; set; }
        public Guid? OutputId { get; set; }
        public MissionOutput Output { get; set; }
    }
}
