using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HelthMind2.Model
{
    [Table("PACIENTE")]
    public class PacienteModel
    {
      
        

            [Key]
            [Required]
            [Column("PACIENTE ID")]
            public int PacienteId { get; set; }

            [Column("NOME")]
            [Required(ErrorMessage = "Nome é obrigatório")]
            public string Nome { get; set; }

            [Column("CPF")]
            [Required(ErrorMessage = "CPF é obrigatório")]
            public string CpfPaciente { get; set; }


            [Column("ESTADO")]
            [Required]
            public string Estado { get; set; }

        public PacienteModel(int pacienteId, string nome, string cpfPaciente, string estado)
        {
            PacienteId = pacienteId;
            Nome = nome;
            CpfPaciente = cpfPaciente;
            Estado = estado;
        }
    }
    }

