using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHub : MonoBehaviour
{
    public MazeGen maze;
    private int[,] mazeMatrice;

    private GameObject PrefabPlayer;
    private List <GameObject> player_list;
    public GameObject minos;
    
    // Start is called before the first frame update
    void Start()
    {
        this.mazeMatrice = maze.GetMatrice();
        maze.AffichageMatrice(mazeMatrice);
        spawnCaracters();
        
    }
    //Accesseur du player
    public List<GameObject> GetPlayer_List()
    {
        return player_list;
    }
    private void spawnCaracters()
    {

        Vector3 spawnPlayer = getAleaSpawn();
        Vector3 spawnMinos = getAleaSpawn();
        player_list[0] = Instantiate(PrefabPlayer, spawnPlayer , Quaternion.identity);
        GameObject unMinos =Instantiate(minos, spawnMinos, Quaternion.identity);
    }
    public Vector3 getPlayerSpawn()
    {
        
        int i = Random.Range(0, maze.GetTailleVisiteX());
        int e = Random.Range(0, maze.GetTailleVisiteX());
        int chose= mazeMatrice[i * maze.GetTailleCellule(), e * maze.GetTailleCellule()];
        Vector3 vec = new Vector3( ((maze.GetTailleCellule() - 1) / 2 +1) * i, 1, ((maze.GetTailleCellule() - 1) / 2+1)*e);
        return vec;
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
        
    }
}
