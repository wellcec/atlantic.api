using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace Atlantic.Api.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio");
            // add the framework services
            var services = new ServiceCollection()
                .AddFluentMigratorCore()
                // Configure the runner
                .ConfigureRunner(
                builder => builder
                // Use SQL
                //.AddSqlServer2012()
                .AddPostgres()
                //.AddPostgres
                // The SQL connection string
                .WithGlobalConnectionString(@"Server=127.0.0.1;Database=AraujoWA;Persist Security Info=True;UID=postgres;PWD=Digital2023")
                // Specify the assembly with the migrations
                .WithMigrationsIn(typeof(Migration01).Assembly))
                .BuildServiceProvider();



            // add StructureMap
            var container = new Container();
            container.Configure(config =>
            {
                // Register stuff in container, using the StructureMap APIs...
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Program));
                    _.WithDefaultConventions();
                    _.AssemblyContainingType<IMigrationRunnerBuilder>();
                });

            });

            try
            {
                using (var scope = services.CreateScope())
                {
                    // Instantiate the runner
                    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                    // Execute the migrations
                    runner.MigrateUp();

                    //Execute the down scripts
                    //runner.RollbackToVersion(0);

                    Console.WriteLine("Migração foi executada com sucesso.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}
