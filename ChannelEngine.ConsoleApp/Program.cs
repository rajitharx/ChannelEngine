namespace ChannelEngine.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = HostBuilder.CreateHostBuilder(args).Build();

            //// Call execute assessment class
            InProgressOrderAssesment.ExecuteAssesment(host);

            Console.ReadLine();
        }
    }
}