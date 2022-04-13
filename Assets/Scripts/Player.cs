using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class Player : MonoBehaviour
{
    private Vector2 position;
    public MazeGen maze;
    private int lives;
    
    
    // Start is called before the first frame update
    void Start()
    {
        position.x = maze.groudSize.x / 2;
        position.y = maze.groudSize.y / 2;
    }

    public void SetPosition(float x, float y)
    {

    }
    public Vector2 GetPosition()
    {
        return new Vector2(position.x, position.y);
    }
}
