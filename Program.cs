using MacabiSongsAPI.Data;
using Microsoft.EntityFrameworkCore;

var uri = "macabi-songs-final.c4conhwhunfk.us-east-1.rds.amazonaws.com";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//"Server=free-tier13.aws-eu-central-1.cockroachlabs.cloud;Database=defaultdb;User Id=orshani1;Password=rUfowXv_MVJg2SYoIp-vsQ;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer($"Server={uri};Initial Catalog=macabi-songs-final;User=admin;Password=orshani1;"));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "https://localhost:7021",
                                              "sql4.freesqldatabase.com",
                                              "*");
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                          policy.AllowAnyOrigin();

                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
