namespace Basis.Desafio.Application.Livros.Responses
{
    public record LivroResponse(int CodI,
                                string Titulo,
                                string Editora,
                                int Edicao,
                                string AnoPublicacao);
}