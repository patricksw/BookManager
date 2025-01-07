namespace Basis.Desafio.Application.Livros.Requests
{
    public record AddLivroRequest(string Titulo, string Editora, int Edicao, string AnoPublicacao);
}