using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TareaRestaurantes.Models;

namespace TareaRestaurantes.Data
{
    public class RestaurantesContext : DbContext
    {
        public RestaurantesContext(DbContextOptions<RestaurantesContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurante> Restaurantes { get; set; }
    }
}
