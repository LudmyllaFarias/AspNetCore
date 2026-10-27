using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers;
/*
 * Resumo
 * Quando alguém acessa a rota /api/alunos
 * 1. O ASP NET identifica a rota correspondente
 * 2. Encontra o AlunoController
 * 3. Identifica o método Listar()
 * 4. Executa esse método
 * 5. Devolve a resposta ao cliente
 */

/*
 * Controller
 * O controle é como se fosse um atendente: recebe a solicitação direciona
 * o que precisa ser feito e devolve uma resposta para o cliente.
 * Cliente -> Pede a lista de produtos
 * Controller -> Recebe a requisição e decide como tráta-la
 * Sistema -> Busca os produtos, se necessário(O controller não precisa buscar dados, ele chama outra classe responsável)
 * Devolve os produtos ao cliente.
 */

/*
 * Routing(Identifica para onde uma requisição deve ser encaminhada
 * Quando o cliente envia GET /alunos o aspNet identifica a rota e redireciona
 * para o método Listar. Agora se a rota for GET /alunos/25 o AspNet identifica que
 * 25 corresponde ao parâmetro id e método recebe esse valor. Em resumo, com base na 
 * url e parâmetro o asp net identifica qual método ele deve chamar.
 */

// Define o caminho usado para acessar o controller
[ApiController]
[Route("api/[controller]")] // Define caminho base para acessar esse controller. [controller] é subistiuído por alunos
public class AlunosController : ControllerBase // fornece funcionalidade úteis para criar controllers como retornar respostas HTTP
{

    [HttpGet] // Indica que o método atende requisições HTTP GET usado para consultar informações
    public IActionResult Listar() // É o método que será executado quando a requisição corresponder à rota e ao verbo HTTP
    {
        return Ok();
    }

    /*
     * Model Binding    
     * Se alguém fizer uma requisição para: GET /produtos?id=10
     * A requisição chega e navegador envia id=10,  o model binding trabalha e identifica o
     * parâmentro id e converte o valor 10 para int. O parâmetro id recebe 10 e o método pode
     * utiliza-lo.
     * Não precisa escrever código para buscar o id da url e nem para converte-lo para inteiro.
     */
    [HttpGet("{id}")]
    public IActionResult ListarAlunosPorId(string id)
    {
        return Ok(id); 
    }

    /*
     * E quanto recebemos um objeto?
     * O model binding participa do processo de obter os dados do
     * parâmetro aluno. Como os dados vem JSON o asp net utiliza a
     * leitura e a desserialização do corpo para transformar esse JSON em 
     * uma objeto. No caso do JSON é o formatador de entrada, baseado em (System.Text.Json) que
     * faz a desserialização.
     * O asp.net pode obter os dados de diferentes lugares: FromRoute, FromQuery, FromBody
     * FromHeader.
     * Em resumo, o model bindings liga os dados da requisição aos parâmentros 
     * do método.
     */
    [HttpPost]
    public IActionResult Cadastrar()
    {
        /*
         * O DTO permite quais informações serão recebidas ou
         * enviadas pela API.
         * No dto colocamos apenas as informações que precisam
         * ser transportadas. Em resumo podemos usar o DTO e expor
         * apenas os dados necessários.
         */

        return Ok();
    }
}
