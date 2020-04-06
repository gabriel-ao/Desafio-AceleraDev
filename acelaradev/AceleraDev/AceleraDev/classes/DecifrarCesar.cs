using AceleraDev.interfaces;

namespace AceleraDev
{
    public class DecifrarCesar : IDecifrarCesar
    {
        public string DecifrarParaCesar(string entrada, int cesar)
        {
            char[] array = entrada.ToCharArray();
            char[] alfabeto = { 'a', 'b','c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 
            'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

            string saida = "";

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '.')
                {
                    saida += '.';
                }
                
                if (array[i] == ',')
                {
                    saida += ',';
                }

                if (array[i] == ' ')
                {
                    saida += ' ';
                }

                for (int j = 0; j < alfabeto.Length; j++)
                {

                    if (array[i] == alfabeto[j])
                    {
                        saida += alfabeto[j - 1];
                    }

                }
            }
            return saida;
        }
    }
}
