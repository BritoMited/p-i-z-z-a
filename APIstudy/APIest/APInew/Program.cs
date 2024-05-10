using Microsoft.AspNetCore.Mvc;
using APInew.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbCtx>();
var app = builder.Build();



app.MapGet("/item/a", ([FromServices] DbCtx ct) => {

    return Results.Ok(ct.Pizzas.ToList());
    
});

app.MapPost("/item/addSabor", ([FromBody] Pizzas pizzas, [FromServices] DbCtx ct) => { 

    ct.Pizzas.Add(pizzas);
    ct.SaveChanges();
    return Results.Ok(pizzas);

});

app.MapGet("/item/sabor/{id}", ([FromRoute] string id, [FromServices] DbCtx ct) => {

    if(ct.Pizzas.Find(id) is null){
        return Results.NotFound();
    }
    return Results.Ok(ct.Pizzas.Find(id));
    
});

app.MapDelete("/item/sabor/deletar/{id}", ([FromRoute] string id, [FromServices] DbCtx ct) => {

    Pizzas? p = ct.Pizzas.Find(id);

    if(ct.Pizzas.Find(id) is null){
        return Results.NotFound();
    }
    ct.Pizzas.Remove(p);
    ct.SaveChanges();
    return Results.Ok("Removed!");
    
});

app.MapPut("/item/sabor/update/{id}", ([FromRoute] string id, [FromBody] Pizzas pi, [FromServices] DbCtx ct) => {

    Pizzas? p = ct.Pizzas.Find(id);

    if(ct.Pizzas.Find(id) is null){
        return Results.NotFound();
    }

    p.Nome = pi.Nome;
    p.Descricao = pi.Descricao;
    p.Valor = pi.Valor;

    ct.Pizzas.Update(p);
    ct.SaveChanges();
    return Results.Ok("Atualizado");
    
});

app.Run();
