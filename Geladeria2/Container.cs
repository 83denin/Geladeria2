namespace Geladeria2
{

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


}
