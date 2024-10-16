using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public PlayerProgress playerProgress;

    public void CompletedMap(int mapIndex)
    {
        playerProgress.lastPlayedMapIndex = mapIndex;
        Debug.Log("Map saved: " + mapIndex);
    }
}
