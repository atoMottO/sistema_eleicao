using EmpregaAI.Services.Interfaces;
using EmpregaAI.Services;
using EmpregaAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura��o da string de conex�o
var connectionString = builder.Configuration.GetConnectionString("CurriculoConnection");
Console.WriteLine($"String de Conex�o: {connectionString}");
// Registrando o DbContext para inje��o
builder.Services.AddDbContext<CurriculoContext>(options =>
    options.UseSqlServer(connectionString));



// Adicionando servi�os ao cont�iner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrando o servi�o ICurriculoService com sua implementa��o CurriculoService
builder.Services.AddScoped<ICurriculoService, CurriculoService>();

// Opcional: se voc� usar AutoMapper, descomente a linha abaixo
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
// Configura��o do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
