﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class ForumPost
    { 
        [Required]
        [MaxLength(20, ErrorMessage = "Username cannot exceed 20 characters")]
        public string UserName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Subject reqires a minimum of 2 characters")]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime PostDate { get; set; }

        public int Id { get; set; }

    }
}