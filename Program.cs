using EmpregaAI.Services.Interfaces;
using EmpregaAI.Services;
using EmpregaAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração da string de conexão
var connectionString = builder.Configuration.GetConnectionString("CurriculoConnection");
Console.WriteLine($"String de Conexão: {connectionString}");
// Registrando o DbContext para injeção
builder.Services.AddDbContext<CurriculoContext>(options =>
    options.UseSqlServer(connectionString));



// Adicionando serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrando o serviço ICurriculoService com sua implementação CurriculoService
builder.Services.AddScoped<ICurriculoService, CurriculoService>();

// Opcional: se você usar AutoMapper, descomente a linha abaixo
// builder.Services.AddAutoMapper(typeof(MappingProfile)); 
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
var app = builder.Build();
app.UseCors();
// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
