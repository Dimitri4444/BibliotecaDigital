using System;
using System.Collections.Generic;

// Classe abstrata base
public abstract class ItemBiblioteca
{
    // Propriedades
    public int Id { get; set; }
    public string Titulo { get; set; }
    protected string DescricaoInterna { get; set; }

    // Construtor
    protected ItemBiblioteca(int id, string titulo)
    {
        Id = id;
        Titulo = titulo;
        DescricaoInterna = "Descrição padrão";
    }
}

// Classe derivada
public class Livro : ItemBiblioteca
{
    // Propriedade adicional
    public string Autor { get; set; }

    // Construtor
    public Livro(int id, string titulo, string autor) : base(id, titulo)
    {
        Autor = autor;
    }

    // Método para exibir a Descrição Interna
    public void ExibirDescricaoInterna()
    {
        Console.WriteLine($"Descrição Interna do Livro '{Titulo}': {DescricaoInterna}");
    }
}

// Classe que gerencia a biblioteca
public class Biblioteca
{
    // Coleção de itens biblioteca
    private List<ItemBiblioteca> colecao;

    // Construtor
    public Biblioteca()
    {
        colecao = new List<ItemBiblioteca>();
    }

    // Método para adicionar um item à coleção
    public void AdicionarItem(ItemBiblioteca item)
    {
        colecao.Add(item);
    }

    // Método para remover um item da coleção por ID
    public void RemoverItem(int id)
    {
        colecao.RemoveAll(item => item.Id == id);
    }

    // Método para buscar um item por título
    public ItemBiblioteca BuscarItemPorTitulo(string titulo)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return colecao.Find(item => item.Titulo == titulo);
#pragma warning restore CS8603 // Possible null reference return.
    }

    // Método para buscar um item por ID
    public ItemBiblioteca BuscarItemPorId(int id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return colecao.Find(item => item.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
    }
}

// Ponto de entrada
public class Program
{
    public static void Main()
    {
        // Criando instâncias de Biblioteca e Livro
        Biblioteca biblioteca = new Biblioteca();
        Livro livro = new Livro(1, "Código Limpo", "Robert C. Martin");

        // Adicionando livro à biblioteca
        biblioteca.AdicionarItem(livro);

        // Buscando livro por título
        ItemBiblioteca itemEncontrado = biblioteca.BuscarItemPorTitulo("Código Limpo");

        if (itemEncontrado != null)
        {
            if (itemEncontrado is Livro livroEncontrado)
            {
                Console.WriteLine($"Livro encontrado: {livroEncontrado.Titulo} por {livroEncontrado.Autor}");

                // Exibindo a Descrição Interna do livro
                livroEncontrado.ExibirDescricaoInterna();
            }
            else
            {
                Console.WriteLine("Item encontrado não é um livro.");
            }
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }

        // Removendo livro por ID
        biblioteca.RemoverItem(1);

        // Tentando encontrar o livro removido
        itemEncontrado = biblioteca.BuscarItemPorId(1);

        if (itemEncontrado == null)
        {
            Console.WriteLine("Livro removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Item encontrado mesmo após a remoção.");
        }
    }
}