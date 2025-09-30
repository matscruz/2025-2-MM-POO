// See https://aka.ms/new-console-template for more information
using System.Globalization;

Console.WriteLine("Hello, World!");

CultureInfo.CurrentCulture = new CultureInfo("pt-BR");


Cartao cartaoBase = new Cartao();
cartaoBase.Debitar(100);
