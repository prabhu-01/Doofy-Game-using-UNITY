using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerData
{
    public float speed;
}

[System.Serializable]
public class PulpitData
{
    public float min_pulpit_destroy_time;
    public float max_pulpit_destroy_time;
    public float pulpit_spawn_time;
}

[System.Serializable]
public class GameData
{
    public PlayerData player_data;
    public PulpitData pulpit_data;
}

public class GameController : MonoBehaviour
{
    public GameData gameData;

    void Start()
    {
        LoadGameData();
    }

    void LoadGameData()
    {
        TextAsset jsonTextFile = Resources.Load<TextAsset>("DoofusDiary");
        if (jsonTextFile != null)
        {
            gameData = JsonUtility.FromJson<GameData>(jsonTextFile.text);
            Debug.Log("Game data loaded successfully.");
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }
}
