using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHub : MonoBehaviour
{
    public MazeGen maze;
    private int[,] mazeMatrice;
    public GameObject player;
    public GameObject minos;

    // Start is called before the first frame update
    void Start()
    {
        maze.Start();
        this.mazeMatrice = maze.GetMatrice();
        spawnCaracters();
        
    }
    private void spawnCaracters()
    {
        Vector3 spawnPlayer = maze.getAleaSpawn();
        Vector3 spawnMinos = maze.getAleaSpawn();
        Instantiate(player,spawnPlayer , Quaternion.identity);
        GameObject unMinos=Instantiate(minos, spawnMinos, Quaternion.identity);
    }
    public Vector3 getPlayerSpawn()
    {
        
        int i = Random.Range(0, maze.GetTailleVisiteX());
        int e = Random.Range(0, maze.GetTailleVisiteX());
        int chose= mazeMatrice[i * maze.GetTailleCellule(), e * maze.GetTailleCellule()];
        Vector3 vec = new Vector3( ((maze.GetTailleCellule() - 1) / 2 +1) * i, 1, ((maze.GetTailleCellule() - 1) / 2+1)*e);
        return vec;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
