﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zno.DAL.Entities
{
    /// <summary>
    /// Модель "предмет"
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}