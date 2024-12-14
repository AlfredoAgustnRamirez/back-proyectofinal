using System;
using Microsoft.AspNetCore.Mvc;
using ProductCategoryCrud.Models;
using ProductCategoryCrud.Data;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductCategoryCrud.Models
{
    //sales
    public class Ventas {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Comprador { get; set; }
        public string Vendedor { get; set; }
        public List<VentasItem> VentasItems { get; set; }  // Relación con los items de la venta

    }
}