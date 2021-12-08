using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using Valve.Newtonsoft.Json;

public class Serializer<TDrawing> //����� �� ������� GameObject ������ TDrawing
{
    private string path = @$"Assets\Data\Serialized_{typeof(TDrawing).Name}.txt"; // �������� -> Resourses?

    public Serializer(string path)
    {
        this.path = path;
    }

    public Serializer()
    {
    }

    public void AddToSerializaiton(StringBuilder str, TDrawing drawing)
        => str.Append(JsonConvert.SerializeObject(drawing));

    public void Serialise(List<TDrawing> drawing)
    {
        using (StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding(1251)))
        {
            sw.WriteLine(JsonConvert.SerializeObject(drawing));
        }
    }

    public List<TDrawing> Deserialize()
    {
        var lines = new List<TDrawing>();
        using (StreamReader sw = new StreamReader(path, Encoding.GetEncoding(1251)))
        {
            var serializedDrawings = sw.ReadToEnd();
            if (serializedDrawings.Length != 0)
                lines = JsonConvert.DeserializeObject<List<TDrawing>>(serializedDrawings);
        }
        return lines;
    }
}
