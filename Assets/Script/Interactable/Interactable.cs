using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void OnClicked()
    {
        Debug.Log(gameObject.name + " was clicked!");
    }
    public virtual void SetActiveAndInteractable(GameObject obj, bool state)
    {
    }
}