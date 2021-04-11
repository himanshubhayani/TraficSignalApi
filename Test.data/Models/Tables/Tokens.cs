using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Test.data.Models
{
    public class Tokens
    {
        [Key,Required]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Users User { get; set; }

        public string Token { get; set; }

        public DateTime CretedDate { get; set; }
    }
}
