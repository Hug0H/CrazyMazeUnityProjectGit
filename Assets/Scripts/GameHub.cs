using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameHub : MonoBehaviour
{
    public MazeGen maze;
    private int[,] mazeMatrice;
   
    public GameObject prefabJoueur;
    private GameObject Joueur;

    public GameObject prefabMinos;
    private GameObject minos;
    
    // Start is called before the first frame update
    void Start()
    {
        
        this.mazeMatrice = maze.GetMatrice();
        maze.AffichageMatrice(mazeMatrice);
        spawnCaracters();
        
    }
    //Accesseur du player
    public GameObject getPlayer()
    {
        return Joueur;
    }
   
    private void spawnCaracters()
    {
        //Vector3 spawnPlayer = getAleaSpawn();
        Vector3 spawnPlayer = new Vector3(1,1,0);
        Vector3 spawnMinos = getAleaSpawn();
        
        Joueur=Instantiate(prefabJoueur, spawnPlayer , Quaternion.identity);
        minos =Instantiate(prefabMinos, spawnMinos, Quaternion.identity);
    }
    
    public Vector3 getAleaSpawn()
    {
        int i = Random.Range(-(maze.GetTailleVisiteX() - 1) / 2, (maze.GetTailleVisiteX() - 1) / 2);
        int y = Random.Range(-(maze.GetTailleVisiteX() - 1) / 2, (maze.GetTailleVisiteX() - 1) / 2);
        Vector3 vec = new Vector3(i * maze.GetTailleCellule(), 2, y * maze.GetTailleCellule());
        return vec;
    }

    // Update is called once per frame
    void Update()
    {

       print(getPosInMaze(Joueur));
    }

    
    public Vector2 getPosInMaze(GameObject o)
    {
        Vector3 posO = o.GetComponent<Transform>().position;

        Vector2 positionInMaze = new Vector2( Mathf.CeilToInt(posO.x) + maze.groudSize.x/2-1, Mathf.CeilToInt(posO.z) + maze.groudSize.y/2 -1);
        return positionInMaze;
    }
}
