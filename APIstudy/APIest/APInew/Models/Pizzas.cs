namespace APInew.Models;

public class Pizzas{

    public Pizzas()
    {
        Id = Guid.NewGuid().ToString();
    }


    public Pizzas(string nome, string descricao, double valor){
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        Id = Guid.NewGuid().ToString();
    }

    //Características - Atributos e propriedades
    public string? Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public double? Valor { get; set; }
}