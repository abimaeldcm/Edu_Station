using Edu_Station.Data;
using Edu_Station.Helpers;
using Edu_Station.Models;
using Edu_Station.Repositorio;
using Edu_Station.Repositorio.Interfaces;
using Edu_Station.Service.AlunoService;
using Edu_Station.Service.DiretorService;
using Edu_Station.Service.DisciplinaService;
using Edu_Station.Service.DocenteService;
using Edu_Station.Service.Interfaces;
using Edu_Station.Service.LoginService;
using Edu_Station.Service.TurmaService;
using Edu_Station.SessaoUsuario;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
  
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddScoped<ILoginService<Diretor ,Login>, DiretorService> ();
builder.Services.AddScoped<ILoginService<Docente ,Login>, DocenteService>();
builder.Services.AddScoped<ILoginService<Aluno ,Login>, AlunoService>();

builder.Services.AddScoped<ILoginRepository<Diretor ,Login>, DiretorRepository>();
builder.Services.AddScoped<ILoginRepository<Docente ,Login>, DocenteRepository>();
builder.Services.AddScoped<ILoginRepository<Aluno ,Login>, AlunoRepository>();


builder.Services.AddScoped<ICRUDService<Diretor>, DiretorService>();
builder.Services.AddScoped<ICRUDService<Login>, LoginService>();
builder.Services.AddScoped<ICRUDService<Docente>, DocenteService>();
builder.Services.AddScoped<ICRUDService<Aluno>, AlunoService>();
builder.Services.AddScoped<ICRUDService<Disciplina>, DisciplinaService>();
builder.Services.AddScoped<ICRUDService<Turma>, TurmaService>();

builder.Services.AddScoped<ICRUDRepository<Diretor>, DiretorRepository>();
builder.Services.AddScoped<ICRUDRepository<Docente>, DocenteRepository>();
builder.Services.AddScoped<ICRUDRepository<Aluno>, AlunoRepository>();
builder.Services.AddScoped<ICRUDRepository<Disciplina>, DisciplinaRepository>();
builder.Services.AddScoped<ICRUDRepository<Turma>, TurmaRepository>();
builder.Services.AddScoped<ICRUDRepository<Login>, LoginRepository>();


builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IVerficadorCodigo, VerificadorCodigo>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ISessao, Sessao>();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".EduStationCookie";
    options.IdleTimeout = TimeSpan.FromSeconds(1000);
    options.Cookie.IsEssential = true;
});
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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}");

app.Run();
