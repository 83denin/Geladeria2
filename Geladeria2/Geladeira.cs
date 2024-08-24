namespace Geladeria2
{
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

}
