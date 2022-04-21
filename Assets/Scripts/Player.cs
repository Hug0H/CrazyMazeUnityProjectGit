using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class Player : MonoBehaviour
{
    public Vector2 positionInMaze;
    public MazeGen maze;
    private int lives;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
       
    }
    void Update()
    {
        
    }
    
   

    public void SetPosition(float x, float y)
    {

    }
    public void setPosInMaze(float halfGround)
    {
        Vector3 posPlayer = gameObject.GetComponent<Transform>().position;
        positionInMaze= new Vector2((int)posPlayer.x + halfGround, (int)posPlayer.z + halfGround);
    }
   
}
