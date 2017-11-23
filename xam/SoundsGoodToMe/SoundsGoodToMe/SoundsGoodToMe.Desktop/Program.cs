using Urho;

namespace SoundsGoodToMe.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            new MyGame(new ApplicationOptions("Data")).Run();
        }
    }
}
