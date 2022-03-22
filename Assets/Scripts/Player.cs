using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class Player : MonoBehaviour
{
    public Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        position.x = 7;
        position.y = 7;
    }
}
