﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendRCVUcab.Persistence.Entities
{

    [NotMapped]

    [Table("Proveedor")]
    public class ProveedorEntity : BaseEntity
    {

        [MaxLength(100)][Required] public string nombre { get; set; }

        [MaxLength(100)][Required] public string direccion { get; set; }

        [MaxLength(100)][Required] public string telefono { get; set; }
       
          public ICollection<MarcaEntity> marcas { get; set; }
       
       
        

    }
}