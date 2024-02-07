using System;
using System.IO;
using System.Xml;
using UnityEngine;

public class XMLReader : MonoBehaviour
{
    private string _fileName = "conf.xml";

    public int amountCoins;
    public int amountHealth;

    private void Awake()
    {
        string path = Application.streamingAssetsPath + "/" + _fileName;

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(path);
        }

        XmlDocument doc = new XmlDocument();
        doc.Load(path);

        XmlNodeList XNL = doc.DocumentElement.ChildNodes;


        amountCoins = Convert.ToInt32(XNL[0].Attributes["value"].Value);
        amountHealth = Convert.ToInt32(XNL[1].Attributes["value"].Value);
    }
}
