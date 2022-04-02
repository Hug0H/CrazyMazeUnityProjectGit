using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHub : MonoBehaviour
{
    public MazeGen maze;
    public GameObject player;
    public GameObject minos;

    // Start is called before the first frame update
    void Start()
    {
        spawnCaracters();
        
    }
    private void spawnCaracters()
    {
        Vector3 spawnPlayer = maze.getAleaSpawn();
        Vector3 spawnMinos = maze.getAleaSpawn();
        print(spawnPlayer);
        Instantiate(player,spawnPlayer , Quaternion.identity);
        Instantiate(minos, spawnMinos, Quaternion.identity);


    }
    public Vector3 getPlayerSpawn()
    {
        
        int i = Random.Range(0, maze.tailleVisiteX);
        int e = Random.Range(0, maze.tailleVisiteY);
        int chose=maze.matrice[i * maze.sizeCellule, e * maze.sizeCellule];
        Vector3 vec = new Vector3( ((maze.sizeCellule-1) / 2 +1) * i, 1, ((maze.sizeCellule-1) / 2+1)*e);
        return vec;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
