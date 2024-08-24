namespace Geladeria2
{
    public class Posicao
    {
        public string Item { get; set; }
        public bool EstaVazia => Item == null;

        public Posicao()
        {
            Item = null;
        }
    }

}
