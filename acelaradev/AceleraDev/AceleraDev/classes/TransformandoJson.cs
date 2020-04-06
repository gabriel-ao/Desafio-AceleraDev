using AceleraDev.Entidades;
using AceleraDev.interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AceleraDev.classes
{
    public class TransformandoJson : ITransformandoJson
    {
        JsonSerializer serializer = new JsonSerializer();

        public void TransformandoEmJson(Answer dados)
        {
            using (StreamWriter sw = new StreamWriter(@"D:\documentos\GitHub\acelaradev\answer.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, dados);
            }
        }
    }
}
