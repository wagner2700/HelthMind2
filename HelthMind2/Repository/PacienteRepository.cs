using HelthMind2.Context;
using HelthMind2.Model;

namespace HelthMind2.Repository
{
    public class PacienteRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public PacienteRepository(DataBaseContext ctx)
        {
            this.dataBaseContext = ctx;
        }

        public IList<PacienteModel> ListarPacientes()
        {
            var listaPacientes = new List<PacienteModel>();

            listaPacientes = dataBaseContext.paciente.ToList<PacienteModel>();

            return listaPacientes;
        }

        public PacienteModel ConsultarPorId(int id)
        {
            var paciente = dataBaseContext.paciente.Find(id);

            return paciente;
        }

        public void InserirPaciente(PacienteModel paciente)
        {
            dataBaseContext.paciente.Add(paciente);
            dataBaseContext.SaveChanges();
        }

        public void ExcluirPaciente(PacienteModel paciente)
        {
            //var pacienteModel = new PacienteModel(id, "", "", "");
            dataBaseContext.paciente.Remove(paciente);
            dataBaseContext.SaveChanges();

        }

        public void AlterarPaciente(PacienteModel pacienteModel)
        {
            dataBaseContext.paciente.Update(pacienteModel);
            dataBaseContext.SaveChanges();
        }
    }
}
