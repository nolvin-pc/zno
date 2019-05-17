﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZnoApi.Models
{
    public class TeacherRegisterViewModel : RegisterViewModel
    {
        [Required]
        [Display(Name = "FIO")]
        [Phone]
        public string Fio { get; set; }
    }
}