namespace AspNetCore.Entities.DTOs;

/*
 * DTO
 * Objeto de transfêrencia de dados
 */
public class RespostaAlunoDTO
{
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
