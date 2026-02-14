// Amir Moeini Rad
// February 2026

// Main Concept: The Dependency Injection Design Pattern

// Dependency Injection means that a class should not create its own dependencies,
// but rather receive them from an external source, such as a constructor or a method parameter.
// This promotes loose coupling and makes the code more testable and maintainable.

namespace DependencyInjectionDP
{
    // An interface for a logger
    public interface ILogger
    {
        void Log(string message);
    }


    // Concrete implementation of the logger interface
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger() 
        {
            Console.WriteLine("Creating logger...");
        }
        
        public void Log(string message)
        {
            Console.WriteLine($"[ConsoleLogger]: {message}");
        }
    }


    ////////////////////////////////////////////////////////
    

    public class UserService 
    {
        private readonly ILogger _logger;

        // Dependency Injection via constructor.
        public UserService(ILogger logger)
        {
            Console.WriteLine("Creating user...");
            _logger = logger;
        }

        public void CreateUser(string name)
        {
            Console.WriteLine($"\nUser '{name}' created.");
            _logger.Log("User created successfully.");
        }
    }

    
    ////////////////////////////////////////////////////////
    

    // Main App
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("The Dependency Injection Design Pattern in C#.NET.");
            Console.WriteLine("--------------------------------------------------\n");

            // Creating the dependency manually
            ILogger logger = new ConsoleLogger();

            // Injecting the dependency manually
            // However, in real scenarios in ASP.NET Core, the dependency is automatically created and injected by the DI container.
            // For example: IServiceCollection.AddSingleton<ILogger, ConsoleLogger>();
            var userService = new UserService(logger);

            userService.CreateUser("Amir");
        }
    }
}
