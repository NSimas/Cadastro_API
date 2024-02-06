using Cadastro.Data;
using Cadastro.Repositorios;
using Cadastro.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Cadastro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure the database
            builder.Services.AddDbContext<CadastroDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

            // Configure dependencies
            builder.Services.AddScoped<IPessoaFisicaRepositorio, PessoaFisicaRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();
            builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
