public class CartaoDebito : Cartao
{
    public override void Debitar(decimal valor)
    {
        Console.WriteLine($"compra {valor:c} realizada no cartão de débito.");
    }
}