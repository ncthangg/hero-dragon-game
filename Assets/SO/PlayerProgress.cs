using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProgress", menuName = "ScriptableObjects/PlayerProgress", order = 1)]
public class PlayerProgress : ScriptableObject
{
    public int lastPlayedMapIndex = 1; // Lưu lại chỉ số của map cuối cùng mà người chơi đã chơi
    private int mapIndexLimit = 4;
    public int GetNowMap()
    {
        var currentMap = lastPlayedMapIndex;
        Debug.Log("Current Map - " + currentMap);
        return currentMap;
    }
    public int GetNextMap()
    {
        var nextMap = lastPlayedMapIndex + 1;
        Debug.Log("Next Map - " + nextMap);
        if (nextMap < mapIndexLimit)
        {
            return nextMap;
        }
        else
        {
            lastPlayedMapIndex = 1;
            return lastPlayedMapIndex;
        }
    }
}
