using AceleraDev.classes;
using AceleraDev.Entidades;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AceleraDev
{
    class Program
    {
        static async Task Main(string[] args)
        {

            DecifrarCesar cesar = new DecifrarCesar();
            CifrarSha1 sha1 = new CifrarSha1();
            Answer dados = new Answer();

            JsonSerializer serializer = new JsonSerializer();

            TransformandoJson transJson = new TransformandoJson();

            string GetUrl = "https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=13f3e758700fe2bfd2ae361a63ff812ba4dc06c3";

            using (var client = new HttpClient())
            {

                using (
                   var message =
                       await client.GetAsync(GetUrl))
                {
                    var RecebendoGetURL = await message.Content.ReadAsStringAsync();

                    File.WriteAllText(@"D:\documentos\GitHub\acelaraDevOnline\answer.json", RecebendoGetURL);
                }

            }

            // chamada do arquivo json
            var json = File.ReadAllText(@"D:\documentos\GitHub\acelaraDevOnline\answer.json");
            var input = JsonConvert.DeserializeObject<Answer>(json);

            // recebendo dados do json para a entidade
            dados.token = input.token;
            dados.numero_casas = input.numero_casas;
            dados.cifrado = input.cifrado;
            dados.decifrado = input.decifrado;
            dados.resumo_criptografico = input.resumo_criptografico;


            dados.decifrado = cesar.DecifrarParaCesar(dados.cifrado, dados.numero_casas);

            // json com descriptografia
            transJson.TransformandoEmJson(dados);

            dados.resumo_criptografico = sha1.CifrarEmSha1(dados.decifrado);

            // json com criptografia SHA1
            transJson.TransformandoEmJson(dados);

            Console.WriteLine("CESAR " + dados.decifrado);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Sha1 " + dados.resumo_criptografico);
            Console.WriteLine("----------------------------------");



            var jsonAlterado = File.ReadAllText(@"D:\documentos\GitHub\acelaraDevOnline\answer.json");


            string url = "https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=";

            url += dados.token;
            Console.WriteLine(url);
            Console.WriteLine("----------------------------------");


            //byte envio = Convert.ToByte(jsonAlterado);
            byte[] envio = Encoding.ASCII.GetBytes(jsonAlterado);

            Console.WriteLine(jsonAlterado);
            Console.WriteLine("----------------------------------");


            using (var client = new HttpClient())
            {
                using (var content =
                    new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
                {
                    content.Add(new StreamContent(new MemoryStream(envio)), "answer", "answer.json");

                    using (
                       var message =
                           await client.PostAsync(url, content))
                    {
                        var inpuut = await message.Content.ReadAsStringAsync();

                        Console.WriteLine("Resposta API");
                        Console.WriteLine(inpuut);
                    }
                }
            }
        }
    }
}
