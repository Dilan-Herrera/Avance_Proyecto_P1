using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Avance_Proyecto_P1.Models;

namespace Avance_Proyecto_P1.Data
{
    public class Avance_Proyecto_P1Context : DbContext
    {
        public Avance_Proyecto_P1Context (DbContextOptions<Avance_Proyecto_P1Context> options)
            : base(options)
        {
        }

        public DbSet<Avance_Proyecto_P1.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<Avance_Proyecto_P1.Models.DetallePedido> DetallePedido { get; set; } = default!;
        public DbSet<Avance_Proyecto_P1.Models.EncabezadoPedido> EncabezadoPedido { get; set; } = default!;
        public DbSet<Avance_Proyecto_P1.Models.Pago> Pago { get; set; } = default!;
        public DbSet<Avance_Proyecto_P1.Models.Pieza> Pieza { get; set; } = default!;
    }
}
