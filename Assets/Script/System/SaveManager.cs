using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public PlayerProgress playerProgress;

    // public void SaveProgress()
    // {
    //     PlayerPrefs.SetInt("LastPlayedMap", playerProgress.lastPlayedMapIndex);
    //     PlayerPrefs.Save();
    //     Debug.Log("Progress saved!");
    // }
    // public void LoadProgress()
    // {
    //     if (PlayerPrefs.HasKey("LastPlayedMap"))
    //     {
    //         playerProgress.lastPlayedMapIndex = PlayerPrefs.GetInt("LastPlayedMap");
    //         Debug.Log("Progress loaded: Map " + playerProgress.lastPlayedMapIndex);
    //     }
    // }
    public void CompleteMap(int mapIndex)
    {
        playerProgress.lastPlayedMapIndex = mapIndex;
        Debug.Log("Map saved: " + mapIndex);
    }
}
