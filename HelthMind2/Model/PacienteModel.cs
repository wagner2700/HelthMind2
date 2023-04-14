using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace HelthMind2.Model
{
    [Table("PACIENTE")]
    public class PacienteModel
    {
      
        

            [Key]
            [Column("PACIENTE ID")]
            public int PacienteId { get; set; }

            [Column("NOME")]
            public string Nome { get; set; }

            [Column("CPF")]
            public string CpfPaciente { get; set; }

            [Column("DATANASCIMENTO")]
            public Calendar DataNascimento { get; set; }

            [Column("ESTADO")]
            public string Estado { get; set; }


            public PacienteModel(string nome, string cpfPaciente, Calendar dataNascimento, string estado)
            {
                Nome = nome;
                CpfPaciente = cpfPaciente;
                DataNascimento = dataNascimento;
                Estado = estado;
            }
        }
    }

