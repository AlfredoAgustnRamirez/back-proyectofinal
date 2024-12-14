using Microsoft.AspNetCore.Mvc;
using ProductCategoryCrud.Models;
using ProductCategoryCrud.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductCategoryCrud.Models
{
    public class VentasItem{
        
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public Product Products { get; set; }  // Relación con el producto

    }
}