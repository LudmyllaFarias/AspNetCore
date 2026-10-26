namespace AspNetCore.Entities.DTOs;

/*
 * DTO
 * Objeto de transfêrencia de dados
 */
public class RequisicaoAlunoDTO
{
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public DateOnly DataNascimento { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
