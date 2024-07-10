using Autofac;
using DependancyInjection;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Serilog.Events;
using static Serilog.Sinks.MSSqlServer.ColumnOptions;

namespace DependencyInjection
{
    internal class Program
    {
        static void Main()
        {
            var connectionString = "Server=WINDOWS-4QT2NDK;Database=LogsDI;User Id=sa;Password=11Jan02*;TrustServerCertificate=True;"; ;
            var seriConnectionString = "Server=(localDB)\\MSSQLLocalDB;Database=MyLogsDB;Trusted_Connection=True;";


            Serilog.Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Information()
                .WriteTo.File(@"C:\Users\tayyi\VS\DependancyInjection\DependancyInjection\LogFile.txt")
                .WriteTo.MSSqlServer(
                    connectionString: seriConnectionString,
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        TableName = "Logs",
                        SchemaName = "dbo",
                        AutoCreateSqlTable = true
                    },
                    restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();


            Console.WriteLine("Dependency Injection Example");
            //--------- create a container ---------------
            var containerBuilder = new ContainerBuilder();

            //--------- Register services -----------------
            containerBuilder.RegisterType<Message>().As<IMessage>().SingleInstance();
            containerBuilder.RegisterType<DependancyInjection.Log>().As<ILog>().SingleInstance();
            containerBuilder.RegisterType<Calculator>().As<ICalculator>().SingleInstance();
            containerBuilder.RegisterType<Database>().As<IDatabase>().SingleInstance().WithParameter("connectionString", connectionString);

            //--------- Build container -------------------
            var container = containerBuilder.Build();
            Console.WriteLine("container has been built");

            //---------- Resolve services ------------------

            var calc = container.Resolve<ICalculator>();
            var db = container.Resolve<IDatabase>();

            //------------- Start program ------------------

            int a = 0, b = 0;
            Console.Write("Enter first number : ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number : ");
            b = Convert.ToInt32(Console.ReadLine());


            int resultAdd = calc.Add(a, b);
            float resultDivide = calc.Divide(a, b);

            Console.WriteLine($"{resultAdd} {resultDivide}");

            db.SaveMessage($"{a} added to {b} = {resultAdd}");
            db.SaveMessage($"{a} divided by {b} = {resultDivide}");

            Console.WriteLine("done");
            Console.ReadLine();
            Serilog.Log.CloseAndFlush();
        }
    }
}

