
using EmpregaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpregaAPI.Data
{
    public class CurriculoContext : DbContext
    {
        public DbSet<Curriculo> Curriculos {  get; set; }
        public CurriculoContext(DbContextOptions<CurriculoContext> opts)
            : base(opts)
        {
            
        }
    }
}
