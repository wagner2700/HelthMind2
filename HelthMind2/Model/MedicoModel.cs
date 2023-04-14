using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HelthMind2.Model
{
    [Table("MEDICO")]
    public class MedicoModel
    {
      
        
            [Key]
            [Column("MEDICOID")]
            public int MedicoId { get; set; }

            [Column("NOMEMEDICO")]
            public string NomeMedico { get; set; }

            [Column("CPF")]
            public string Cpf { get; set; }

            [Column("ESPECIALIDADE")]
            public string Especialidade { get; set; }

            //[Column("DATANASCIMENTO")]
            //public Calendar DataNacimento { get; set; }

            [Column("CRM")]
            public string CRMMedico { get; set; }

        public MedicoModel(int medicoId, string nomeMedico, string cpf, string especialidade, string cRMMedico)
        {
            MedicoId = medicoId;
            NomeMedico = nomeMedico;
            Cpf = cpf;
            Especialidade = especialidade;
            CRMMedico = cRMMedico;
        }

        public MedicoModel(int medicoId)
        {
            MedicoId = medicoId;
         
        }
    }
    }

