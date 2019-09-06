using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public string SceneName;
    public string LevelNumber;
    public float Time1;
    public float Time2;
    public float Time3;
    public bool UnLocked;
    public bool IsInteractable;
    public int Stars;
    public int StarsToUnlockLevel;
}
