namespace CheckoutKata
{
    public class Program
    {
        static void Main(string[] args)
        {
            StaticDependencies.Init();
            var App = new App();

            App.Run();
        }
    }
}
