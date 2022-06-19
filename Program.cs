using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebAPIDemo.Context;
using WebAPIDemo.Data;
using WebAPIDemo.Models;

var builder = WebApplication.CreateBuilder(args);


var connstring = builder.Configuration.GetConnectionString("LoginFlowDB");
builder.Services.AddDbContext<LoginFlowDBContext>(options=> options.UseSqlServer(connstring));


builder.Services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<LoginFlowDBContext>()
    .AddDefaultTokenProviders(); ;



builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc(SwaggerConfiguration.DocNameV1,
                       new OpenApiInfo
                       {
                           Title = SwaggerConfiguration.DocInfoTitle,
                           Version = SwaggerConfiguration.DocInfoVersion,
                           Description = SwaggerConfiguration.DocInfoDescription
                       });

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = SwaggerConfiguration.SecuritySchemeDescription,
        Name = SwaggerConfiguration.SecuritySchemeName,
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = SwaggerConfiguration.SecurityScheme.ToLower(),
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = SwaggerConfiguration.SecurityScheme
        }
    };

    swagger.AddSecurityDefinition(SwaggerConfiguration.SecurityScheme, securitySchema);

    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});


builder.Services.AddAuthentication(f =>
{
    f.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    f.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(k =>
{
	var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
	k.SaveToken = true;
    k.IncludeErrorDetails = true;
	k.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["JWT:Issuer"],
		ValidAudience = builder.Configuration["JWT:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(Key),
        ClockSkew = TimeSpan.Zero
    };

});

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
