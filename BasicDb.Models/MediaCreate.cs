﻿using BasicDb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Models
{
    class MediaCreate
    {
        [Key]
        public int MediaId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public MediaType Medium { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
