
using book_store_ziad.Data;
using book_store_ziad.Repos.AuthorRepo;
using book_store_ziad.Repos.BookRepo;
using book_store_ziad.Repos.GenreRepo;
using Microsoft.EntityFrameworkCore;

namespace book_store_ziad
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connection = builder.Configuration.GetConnectionString("MyDeafult");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
            builder.Services.AddScoped<IBookRepo,BookRepo>();
            builder.Services.AddScoped<IAuthorRepo,AuthorRepo>();
            builder.Services.AddScoped<IGenreRepo,GenreRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
