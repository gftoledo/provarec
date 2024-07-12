using MinimalApiProject.Models;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();

//Configurar a política de CORS
builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);

var app = builder.Build();


app.MapGet("/", () => "Prova");




//POST: http://localhost:5273/imcs/cadastrar
app.MapPost("/usuario/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] Usuario usuario) =>
{
    Usuario? usuario = ctx.Usuarios.Find(Usuario.UsuarioId);
    if (categoria == null)
    {
        return Results.NotFound("usuario não existe");
    }
    usuario.Usuario = usuario;
    ctx.Usuario.Add(usuario);
    ctx.SaveChanges();
    return Results.Created("", usaurio);
});




//GET: http://localhost:5273/imcs/listar
app.MapGet("/imcs/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Imcs.Any())
    {
        return Results.Ok(ctx.Imcs.ToList());
    }
    return Results.NotFound("Nenhum Imc encontrado");
});

//POST: http://localhost:5273/imcs/cadastrar
app.MapPost("/imcs/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] Imcs imcs) =>
{
    Imcs? imcs = ctx.Imcs.Find(usuario.ImcsId);
    if (imcs == null)
    {
        return Results.NotFound("usuario não encontrado");
    }
    imcs.Usuario = usuario;
    ctx.Imcs.Add(Imcs);
    ctx.SaveChanges();
    return Results.Created("", Imcs);
});

//PUT: http://localhost:5273/imcs/alterar/{id}
app.MapPut("/imcs/alterar/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    //Implementar a alteração do status da tarefa
    Imcs? imcs = ctx.Imcs.Find(id);
    if (imcs is null)
    {
        return Results.NotFound("Imc não encontrado");
    }
    
    ctx.Imcs.Update(imcs);
    ctx.SaveChanges();
    return Results.Ok(ctx.Imcs.ToList());
});

app.UseCors("Acesso Total");
app.Run();






















