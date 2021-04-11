using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Test.data.Models
{
    public class GlobalConfiguration
    {
        [Key,Required]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Users User { get; set; }

        public int Direction { get; set; }

        public int TimeInterval { get; set; }
    }
}
