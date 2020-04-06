using AceleraDev.interfaces;
using System.Security.Cryptography;
using System;
using System.Text;

namespace AceleraDev.classes
{
    public class CifrarSha1 : ICifrarSha1
    {
        public string CifrarEmSha1(string entrada)
        {
            byte[] data = Encoding.ASCII.GetBytes(entrada);
            string _add = "";

            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.
            byte[] result = sha.ComputeHash(data);

            foreach(byte b in result)
            {
                _add += String.Format("{0:x2}", b);
            }

            return _add;

            

        }
    }
}
