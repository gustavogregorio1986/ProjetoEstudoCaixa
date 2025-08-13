using Microsoft.EntityFrameworkCore;
using ProjetoEstudoCaixa.Data.Context;
using ProjetoEstudoCaixa.Data.Respository;
using ProjetoEstudoCaixa.Data.Respository.Interface;
using ProjetoEstudoCaixa.Service.Service;
using ProjetoEstudoCaixa.Service.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// 1 - Definir uma política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MinhaPoliticaCors",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // front-end que vai acessar a API
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CaixaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 2 - Usar o middleware CORS
app.UseCors("MinhaPoliticaCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
