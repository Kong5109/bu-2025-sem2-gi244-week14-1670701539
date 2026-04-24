using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private static MainManager instance;
    public static MainManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    public Color TeamColor = Color.white;

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
        public string MyName;
    }

    public void SaveColor()
    {
        //string folder = "C:\\Users\\Administrator\\Downloads";
        string folder = Application.persistentDataPath;
        string fileName = "saveData.json";
        string fullPath = Path.Combine(folder, fileName);

        SaveData data = new SaveData();
        data.TeamColor = TeamColor;
        data.MyName = "Big";
        string j = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("saveData", j);
        Debug.Log(j);
        Debug.Log(fullPath);

        File.WriteAllText(fullPath, j);
        /*PlayerPrefs.SetFloat("TeamColor.r", TeamColor.r);
        PlayerPrefs.SetFloat("TeamColor.g", TeamColor.g);
        PlayerPrefs.SetFloat("TeamColor.b", TeamColor.b);
        PlayerPrefs.SetFloat("TeamColor.a", TeamColor.a);*/
    }

    public void LoadColor()
    {
        string folder = Application.persistentDataPath;
        string fileName = "saveData.json";
        string fullPath = Path.Combine(folder, fileName);

        if (File.Exists(fullPath))
        {
            string j = File.ReadAllText("saveData");
            SaveData data = JsonUtility.FromJson<SaveData>(j);
            TeamColor = data.TeamColor;
        }

        /*TeamColor.r = PlayerPrefs.GetFloat("TeamColor.r");
        TeamColor.g = PlayerPrefs.GetFloat("TeamColor.g");
        TeamColor.b = PlayerPrefs.GetFloat("TeamColor.b");
        TeamColor.a = PlayerPrefs.GetFloat("TeamColor.a");*/
    }
}
