﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dreams.Web.Data.Entities
{
    public class UnitEntity
    {

        public int Id { get; set; }

        [StringLength(20,  ErrorMessage = "The {0} field must have {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Code { get; set; }

        [StringLength(100,  ErrorMessage = "The {0} field must have {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Descripcion { get; set; }

        
        [DataType(DataType.DateTime)]
        [Display(Name = "Create Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime CreateDate { get; set; }

        public DateTime CreateDateLocal => CreateDate.ToLocalTime();

        [DataType(DataType.DateTime)]
        [Display(Name = "Update Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime UpdateDate { get; set; }

        public DateTime UpdateDateLocal => UpdateDate.ToLocalTime();


    }
}
