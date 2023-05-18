using MySqlConnector;

namespace ParkingLot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Server=127.0.0.1;User ID=zuppremodev;Password=deybi;Database=bda_2023
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<MySqlConnection>(_ =>
            new MySqlConnection(builder.Configuration.GetConnectionString("Default")));

            using var connection = new MySqlConnection("Server=127.0.0.1;User ID=zuppremodev;Password=deybi;Database=bda_2023");
            connection.Open();
            using var command = new MySqlCommand("SELECT * FROM Persona", connection);
            Console.WriteLine("Select mysql query ");
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}, \t {reader.GetString(1)}");
            }
            reader.Close();
            command.CommandText = "SELECT @@VERSION";
            Console.WriteLine("Select version of mysql");
            using var reader2 = command.ExecuteReader();
            while (reader2.Read())
            {
                Console.WriteLine($"{reader2.GetString(0)}");
            }
            reader2.Close();

            command.CommandText = "SHOW DATABASES";
            Console.WriteLine("show databases");
            using var reader3 = command.ExecuteReader();
            while (reader3.Read())
            {
                Console.WriteLine($"{reader3.GetString(0)}");
            }
            reader3.Close();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}