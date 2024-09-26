using System.ComponentModel.DataAnnotations;

namespace At_Net_Q4.Model
{
	public class Usuario
	{
		public int Id { get; set; }
		[Required(ErrorMessage="O nome é obrigatório")]
		[StringLength(30, ErrorMessage = "O nome deve ter até 30 caracteres")]
		public string Nome {  get; set; }
		[Required(ErrorMessage = "O e-mail é obrigatório")]
		[EmailAddress(ErrorMessage ="O e-mail deve ser válido")]
		public string Email { get; set; }
		[Required(ErrorMessage = "A data de nascimento é obrigatória")]
		[DataType(DataType.Date)]
		public DateTime DataNascimento { get; set; }
		
	}
}
