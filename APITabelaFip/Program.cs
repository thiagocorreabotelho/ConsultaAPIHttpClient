// See https://aka.ms/new-console-template for more information
using APITabelaFip;
using System.Text.Json;

Console.WriteLine("Digite o modelo do seu veículo! (Carros) (Motos) (Caminhões)");

var tipoVeiculos = Console.ReadLine();

if (string.IsNullOrEmpty(tipoVeiculos))
{
    Console.WriteLine("Infelizmente não podemos dar continuidade na consulta, pois o tipo fornecedido é inválido! \n Por favor tente novamente ou mais tarde.");
}

var endpoint = $"https://parallelum.com.br/fipe/api/v1/{tipoVeiculos}/marcas";

var client = new HttpClient();

try
{
    HttpResponseMessage? response = await client.GetAsync(endpoint);
    response.EnsureSuccessStatusCode();

    string retornoBody = await response.Content.ReadAsStringAsync();

    List<Veiculo> veiculos = JsonSerializer.Deserialize<List<Veiculo>>(retornoBody);

    foreach (var item in veiculos)
    {
        Console.WriteLine($"Marca do {tipoVeiculos} é: {item.nome} - O código do {tipoVeiculos} é {item.codigo}");
    }
}
catch (Exception)
{

    throw;
}