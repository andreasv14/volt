using Volt.Application;
using Volt.Infrastructure;
using Volt.WebAPI;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .ConfigureSwaggerAPI()
        .ConfigureCors();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("MyPolicy");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.Run();
}