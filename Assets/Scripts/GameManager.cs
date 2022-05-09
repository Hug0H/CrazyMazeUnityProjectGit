using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        Menu,
        Play,
        Win,
        GameOver
    };
    public State GameState;
    public GameObject prefabGround;
    public GameObject Ground;
    public GameObject prefabGameHub;
    public GameObject GameHub;
    public GameObject Menu;
    public GameObject PrefabMapCinematique;
    private GameObject MapCinematique;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject camCinematique;
    // Start is called before the first frame update
    void Start()
    {
        GameState = State.Menu;
        Menu = GameObject.FindGameObjectWithTag("Menu");
        Menu.SetActive(false);
        MapCinematique = Instantiate(PrefabMapCinematique, new Vector3(0, 0, 0), Quaternion.identity);

    }
    public void StartNewGame()
    {
        camCinematique.SetActive(false);
        cam1.SetActive(true);
        cam2.SetActive(true);
        MapCinematique.SetActive(false);
                   
        if (Ground != null)
        {
            Destroy(Ground);
        }
       Ground = Instantiate(prefabGround, new Vector3(0, 0, 0),Quaternion.identity);
        Ground.transform.Rotate(90, 0, 0, 0);
        GameObject Gh = GameObject.FindGameObjectWithTag("GameHub");
        if (Gh!= null)
        {
            Destroy(Gh);
        }
    GameHub=Instantiate(prefabGameHub, new Vector3(0, 0, 0), Quaternion.identity);
    GameHub.GetComponent<GameHub>().maze = Ground.GetComponent<MazeGen>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
