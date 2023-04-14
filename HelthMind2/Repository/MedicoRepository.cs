using HelthMind2.Context;
using HelthMind2.Model;
 
namespace HelthMind2.Repository
{
    public class MedicoRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public MedicoRepository(DataBaseContext ctx)
        {
            this.dataBaseContext = ctx;
        }

        public IList<MedicoModel> Listar()
        {
            var lista = new List<MedicoModel>();

            lista = dataBaseContext.medico.ToList<MedicoModel>();

            return lista;
        }

        public MedicoModel ConsultarPorId(int id)
        {
            var medico = dataBaseContext.medico.Find(id);

            return medico;
        }

        public void Inserir(MedicoModel medico)
        {
            dataBaseContext.medico.Add(medico);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
        var medico = new MedicoModel( id ,"","","","");
        }
    }
}
