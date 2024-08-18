using System;
using System.Collections.Generic;

public class Posicao
{
    public string Item { get; set; }
    public bool EstaVazia => Item == null;

    public Posicao()
    {
        Item = null;
    }
}

public class Container
{
    public List<Posicao> Posicoes { get; private set; }
    public bool EstaVazio => Posicoes.All(p => p.EstaVazia);
    public bool EstaCheio => Posicoes.All(p => !p.EstaVazia);

    public Container()
    {
        Posicoes = new List<Posicao>
        {
            new Posicao(), new Posicao(), new Posicao(), new Posicao()
        };
    }

    public void AdicionarItem(int posicaoIndex, string item)
    {
        if (posicaoIndex < 0 || posicaoIndex >= Posicoes.Count)
        {
            Console.WriteLine("Posição inválida.");
            return;
        }

        if (Posicoes[posicaoIndex].EstaVazia)
        {
            Posicoes[posicaoIndex].Item = item;
            Console.WriteLine($"Item '{item}' adicionado na posição {posicaoIndex}.");
        }
        else
        {
            Console.WriteLine("Posição já ocupada.");
        }
    }

    public void RemoverItem(int posicaoIndex)
    {
        if (posicaoIndex < 0 || posicaoIndex >= Posicoes.Count)
        {
            Console.WriteLine("Posição inválida.");
            return;
        }

        if (!Posicoes[posicaoIndex].EstaVazia)
        {
            Posicoes[posicaoIndex].Item = null;
            Console.WriteLine($"Item removido da posição {posicaoIndex}.");
        }
        else
        {
            Console.WriteLine("Posição já está vazia.");
        }
    }

    public void RemoverTodosItens()
    {
        if (EstaVazio)
        {
            Console.WriteLine("Container já está vazio.");
            return;
        }

        foreach (var posicao in Posicoes)
        {
            posicao.Item = null;
        }

        Console.WriteLine("Todos os itens foram removidos do container.");
    }

    public void AdicionarItemEmContainer(int posicaoIndex, string item)
    {
        if (EstaCheio)
        {
            Console.WriteLine("Container já está cheio.");
            return;
        }

        AdicionarItem(posicaoIndex, item);
    }
}

public class Andar
{
    public List<Container> Containers { get; private set; }

    public Andar()
    {
        Containers = new List<Container>
        {
            new Container(), new Container()
        };
    }
}

public class Geladeira
{
    public List<Andar> Andares { get; private set; }

    public Geladeira()
    {
        Andares = new List<Andar>
        {
            new Andar(), new Andar(), new Andar()
        };
    }

    public void ImprimirItens()
    {
        for (int i = 0; i < Andares.Count; i++)
        {
            Console.WriteLine($"Andar {i}:");

            for (int j = 0; j < Andares[i].Containers.Count; j++)
            {
                Console.WriteLine($"  Container {j}:");

                for (int k = 0; k < Andares[i].Containers[j].Posicoes.Count; k++)
                {
                    var posicao = Andares[i].Containers[j].Posicoes[k];
                    var item = posicao.EstaVazia ? "Vazio" : posicao.Item;
                    Console.WriteLine($"    Posição {k}: {item}");
                }
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        var geladeira = new Geladeira();
        geladeira.ImprimirItens();

        geladeira.Andares[0].Containers[0].AdicionarItem(0, "Maçã");
        geladeira.Andares[1].Containers[1].AdicionarItem(2, "Leite");
        geladeira.Andares[2].Containers[1].AdicionarItem(3, "Presunto");

        Console.WriteLine("\nApós adicionar alguns itens:");
        geladeira.ImprimirItens();

        geladeira.Andares[0].Containers[0].RemoverItem(0);

        Console.WriteLine("\nApós remover um item:");
        geladeira.ImprimirItens();
    }
}
