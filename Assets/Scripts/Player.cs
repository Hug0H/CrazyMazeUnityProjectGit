using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class Player : MonoBehaviour
{
    private Vector2 positionInMaze;
    public MazeGen maze;
    private int lives;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
       
    }
    public Vector2 getPosInMaze()
    {
        return positionInMaze;
    }
    public void setPosInMaze(Vector2 pos)
    {
         positionInMaze=pos;
    }

    public void SetPosition(float x, float y)
    {

    }
   
}
