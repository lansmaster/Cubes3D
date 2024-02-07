using System.IO;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    private string _fileName = "save.json";
    private JSONFile _JSONFile = new JSONFile();

    public int amountCoins;
    public int amountHealth;

    private void Awake()
    {
        string path = Application.streamingAssetsPath + "/" + _fileName;

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(path);
        }

        _JSONFile = JsonUtility.FromJson<JSONFile>(File.ReadAllText(path));

        amountCoins = _JSONFile.coins;
        amountHealth = _JSONFile.health;
    }
}

public class JSONFile
{
    public int coins;
    public int health;
}
