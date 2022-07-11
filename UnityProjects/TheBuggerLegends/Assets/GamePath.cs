using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GamePath", menuName = "GamePath")]
public class GamePath : ScriptableObject
{
    public enum Path
    {
        Top,
        Left,
        Right,
        Bottom
    }

    public List<Path> pathToArrive = new List<Path>();
}
