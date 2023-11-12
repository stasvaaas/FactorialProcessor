namespace FactorialProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FactorialProcessor processor = new FactorialProcessor();

            Console.WriteLine("Parallel Mode:");
            processor.Go(15, true);

            Console.WriteLine("\nSequential Mode:");
            processor.Go(10, false);
        }
    }
}