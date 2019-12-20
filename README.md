# Criando-Log-Com-Serilog-CSharp
Exemplo de criação de Logs com Serilog C#

## Packages

https://serilog.net/


- Install - Package Serilog
- Install - Package Serilog.Sinks.Console
- Install - Package Serilog.Sinks.File

## Código

```c#
  static void Main(string[] args)
  {
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
```
