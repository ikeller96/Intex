﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    [Table("MaterialsList")]
    public class MaterialsList
    {
        [Key]
        public int MaterialsListID { get; set; }

        [DisplayName("Material ID")]
        public int MaterialID { get; set; }

        [DisplayName("Quantity Used")]
        public int QuantityUsed { get; set; }


    }
}