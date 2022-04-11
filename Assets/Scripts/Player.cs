using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class Player : MonoBehaviour
{
    public Vector2 position;
    public MazeGen maze;
    // Start is called before the first frame update
    void Start()
    {
        position.x = maze.groudSize.x / 2;
        position.y = maze.groudSize.y / 2;
    }
}
