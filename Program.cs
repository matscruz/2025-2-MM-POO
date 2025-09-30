using System;

class Programa
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao simulador de TV!\n");

        Televisao tv = new Televisao(55f);
        Console.WriteLine($"A TV de {tv.Tamanho} polegadas está desligada.");

        // Simula o último canal assistido antes de ligar
        tv.IrParaCanal(42);
        tv.Desligar();
        Console.WriteLine($"\nConfigurando o último canal assistido para 42.");

        // Ligar a TV e verificar o canal
        tv.Ligar();
        Console.WriteLine($"\nTV ligada. O volume inicial é {tv.Volume} e o canal é {tv.Canal}.");
        // Saída esperada: "canal é 42"

        // Testar a regra de volume: valores fora dos limites
        tv.DefinirVolume(120);
        Console.WriteLine($"\nTentativa de definir volume para 120. Volume atual: {tv.Volume}"); // Deve ser 100

        tv.DefinirVolume(-10);
        Console.WriteLine($"Tentativa de definir volume para -10. Volume atual: {tv.Volume}"); // Deve ser 0

        // Aumentar e reduzir volume
        tv.DefinirVolume(50);
        Console.WriteLine($"\nVolume definido para 50.");
        tv.AumentarVolume();
        Console.WriteLine($"Volume aumentado. Volume atual: {tv.Volume}"); // Deve ser 51
        tv.ReduzirVolume();
        Console.WriteLine($"Volume reduzido. Volume atual: {tv.Volume}"); // Deve ser 50

        // Testar o modo mudo
        Console.WriteLine("\nAtivando o mudo...");
        tv.AtivarMudo();
        Console.WriteLine($"Volume com mudo ativado: {tv.Volume}"); // Deve ser 0

        Console.WriteLine("Desativando o mudo...");
        tv.DesativarMudo();
        Console.WriteLine($"Volume com mudo desativado: {tv.Volume}"); // Deve retornar a 50

        // Testar a regra de canais
        tv.IrParaCanal(100);
        Console.WriteLine($"\nMudando para o canal 100. Canal atual: {tv.Canal}"); // Deve ser 100

        tv.AumentarCanal();
        Console.WriteLine($"Aumentando canal. Canal atual: {tv.Canal}"); // Deve ser 101

        tv.ReduzirCanal();
        Console.WriteLine($"Reduzindo canal. Canal atual: {tv.Canal}"); // Deve ser 100

        // Testar looping de canais
        tv.IrParaCanal(Televisao.CANAL_MAXIMO);
        Console.WriteLine($"\nCanal atual: {tv.Canal}"); // Deve ser 520
        tv.AumentarCanal();
        Console.WriteLine($"Aumentando canal. Canal atual: {tv.Canal}"); // Deve voltar para o 1

        tv.IrParaCanal(Televisao.CANAL_MINIMO);
        Console.WriteLine($"\nCanal atual: {tv.Canal}"); // Deve ser 1
        tv.ReduzirCanal();
        Console.WriteLine($"Reduzindo canal. Canal atual: {tv.Canal}"); // Deve voltar para o 520
    }
}