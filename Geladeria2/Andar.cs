namespace Geladeria2
{
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

}
