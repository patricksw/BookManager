namespace Basis.Desafio.Application.Livros.Requests
{
    public record EditLivroRequest(string Titulo, string Editora, int Edicao, string AnoPublicacao);
}