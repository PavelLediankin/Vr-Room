using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using Photon.Pun;

public class SerializationController : MonoBehaviour
{
    List<LineRenderer> lines = new List<LineRenderer>(); //����� �� �������� ����� ������������ GameObkect
    StringBuilder str = new StringBuilder();
    Serializer<LineRenderer> serializer = new Serializer<LineRenderer>(); 

    public void AddLine(LineRenderer line)
    {
        lines.Add(line); // ����� �������������� � ������� ��� ����� �������� ���������(��������) ������ �����
        serializer.AddToSerializaiton(str, line);
    }

    /// <summary>
    /// ������� ����� ��������� �������. ����?
    /// </summary>
    public void Serialize()
    {
        serializer.Serialise(lines);
    }

    public void Deserialize(GameObject brush)
    {
        var lines = serializer.Deserialize();
        foreach(var l in lines)
        {
            PhotonNetwork.Instantiate(brush.name, l.transform.position, Quaternion.identity);
        }
    }
}
