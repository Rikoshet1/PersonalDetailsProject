using MyProject.Context;
using MyProject.Repositories.Interfaces;
using MyProject.Services;
using MyProject.Services.Interfaces;
using MyProject.Services.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServices();
builder.Services.AddScoped<IChildService, ChildService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddControllers();

builder.Services.AddDbContext<IContext, DataContext>();
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddHttpContextAccessor();

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

app.UseCors(x => x
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());

app.UseHttpsRedirection();

//app.UseCors("ReactPolicy");



app.UseAuthorization();

app.MapControllers();

app.Run();
