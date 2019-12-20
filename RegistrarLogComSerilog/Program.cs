using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarLogComSerilog
{
    class Program
    {
        static void Main(string[] args)
        {

            // Install - Package Serilog
            // Install - Package Serilog.Sinks.Console
            // Install - Package Serilog.Sinks.File

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("Log.txt",
                    rollingInterval: RollingInterval.Minute,
                    rollOnFileSizeLimit: true)
                .CreateLogger();

            while (true)
            {
                try
                {
                    Console.WriteLine("Informe o nome do Cliente: ");
                    var nome = Console.ReadLine();

                    Console.WriteLine("Informe o Valor da Venda: ");
                    double valor = double.Parse(Console.ReadLine());

                    var cliente = new { nome, valor };

                    Log.Information($"Dados lidos com sucesso: {@cliente} ");

                    Console.WriteLine("Sair (X)");
                    if (Console.ReadLine() == "X")
                        break;
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                }
            }

            Log.CloseAndFlush();
        }
    }
}
