using HelthMind2.Model;
using Microsoft.EntityFrameworkCore;

namespace HelthMind2.Context
{
    public class DataBaseContext: DbContext
    {
        
        // Propriedade responsável pelo acesso Medico
        public DbSet<MedicoModel> medico { get; set; }

        // Propriedade responsável pelo acesso Paciente
        //public DbSet<PacienteModel> paciente { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DataBaseContext()
        {
        }
    }
}
