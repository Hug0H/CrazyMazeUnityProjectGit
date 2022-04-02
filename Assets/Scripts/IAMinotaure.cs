using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IAMinotaure : MonoBehaviour
{
    public MazeGen maze;
    public int[,] DIST;
    public int[,] matrice;
    public int [] position;
    public Player players = new Player();

    int tailleX;
    int tailleY;

    int compteur;
    // Start is called before the first frame update
    void Start()
    {

        maze.Start();

        matrice = maze.matrice;
        AffichageMatrice(matrice);

        // AffichageMatrice(maze.matrice);

        //AffichageMatrice(maze.matrice);

        //DIST = new int[matrice.GetLength(0), matrice.GetLength(1)];
        //DIST = new int[100, 100];
        DIST = (int[,]) matrice.Clone();
        //System.Array.Copy(maze.matrice, DIST, 5000);
        //matrice = maze.GenLab();
        //System.Array.Copy(maze.GenLab(),matrice, maze.GenLab().Length);
        //AffichageMatrice(DIST);

        tailleX = DIST.GetLength(0);
        tailleY = DIST.GetLength(1);

        //Poisition de départ du minautore.
        position = new int [2];
        position[0] = 1;
        position[1] = 1;
    }

    //Initialisation de la carte des distances
    int[,] PreInitDistPlayer()
    {
        for (int x = 0; x < tailleX; x++)
        {
            for (int y = 0; y < tailleY; y++)
            {
                if (matrice[x, y] == 1)
                {
                    DIST[x, y] = 999;
                }
                else
                {
                    DIST[x, y] = 30;
                }
            }
        }
        return DIST;
    }
    int[,] InitDistPlayer(int xp, int yp)
    {
        xp += (int)(maze.groudSize.x / 2);
        yp += (int)(maze.groudSize.y / 2);
        for (int x = 0; x < tailleX; x++)
        {
            for (int y = 0; y < tailleY; y++)
            {
                if (DIST[x, y] == 0)
                {
                    continue;
                }
                else if(DIST[x, y] == 999)
                {
                    continue;
                }
                else if (x == xp && y==yp)
                {
                    DIST[x, y] = 0;
                }
                else
                {
                    DIST[x, y] = 30;
                }
            }
        }
        return DIST;
    }

    int[,] UpdateDistPlayer()
    {
        print("coucou");
        for (int x = 1; x < tailleX-1; x++)
        {
            for (int y = 1; y < tailleY-1; y++)
            {
                print("coucou1");
                if (DIST[x, y] == 999)
                {
                    print("coucou2");
                    continue;
                }
                else
                {
                    int valeurMin = Minimum(new int[4] { DIST[position[0] + 1, position[1]], DIST[position[0], position[1] + 1], DIST[position[0] - 1, position[1]], DIST[position[0], position[1] - 1] });
                    print("valeurMin : " + valeurMin);
                    if (DIST[x, y] > valeurMin)
                    {
                        DIST[x, y] = valeurMin + 1;
                        print("coucou3");
                    }
                    print("coucou4");
                }
            }
        }
        return DIST;
    }

    int[,] CalculDistPlayer(int xp, int yp)
    {
        InitDistPlayer(xp, yp);
        AffichageMatrice(DIST);
        // Parcours de calcules des distances
        for (int i = 0; i < 2; i++)
        {
            UpdateDistPlayer();
        }
        return DIST;
    }

    string [] MinautorePossibleMove()
    {
        string [] choixPossibles = new string [4];
        compteur = 0;
        int valeurMin = Minimum(new int [4] {DIST[position[0] + 1, position[1]],DIST[position[0], position[1] + 1], DIST[position[0] - 1, position[1]], DIST[position[0], position[1] - 1]});
        //print("ValeurMin : " + valeurMin);
        if (DIST[position[0], position[1] - 1] == valeurMin)
        {
            choixPossibles[compteur]="haut";
            compteur += 1;
        }
        if (DIST[position[0], position[1] + 1] == valeurMin)
        {
            choixPossibles[compteur] = "bas";
            compteur += 1;
        }
        if (DIST[position[0] + 1, position[1]] == valeurMin)
        {
            choixPossibles[compteur] = "droite";
            compteur += 1;
        }
        if (DIST[position[0] - 1, position[1]] == valeurMin)
        {
            choixPossibles[compteur] = "gauche";
            compteur += 1;
        }
        return choixPossibles;
    }
    void IA()
    {
        DIST = PreInitDistPlayer();
        DIST = CalculDistPlayer((int)players.position.x, (int)players.position.y);

        //deplacement Minautore
        string [] choixPossibles = MinautorePossibleMove();
        int choix = Random.Range(0, compteur);
        string result = choixPossibles[choix];
        if (result == "droite")
        {
            position[0] += 1;
        }
        else if (result == "gauche")
        {
            position[0] -= 1;
        }
        else if (result == "haut")
        {
            position[1] -= 1;
        }
        else if (result == "bas")
        {
            position[1] += 1;
        }
        print("PositionXMinautore : " + position[0] + "  /  PositionYMinautore : " + position[1]);

        if (position[0] == players.position.x && players.position.y == position[1])
        {
            print("collision");
            //Application.Quit();
        }
    }
   

    // Update is called once per frame
    void Update()
    {
       
        //AffichageMatrice(matrice);
        IA();
        AffichageMatrice(DIST);
    }


    //Fonctions utilitaires à déplacer dans un fichier utilitaire
    int Minimum(int [] tab)
    {
        int mimimum=999;
        for(int i=0; i< tab.Length; i++)
        {
            if (mimimum > tab[i])
            {
                mimimum = tab[i];
            }
        }
        return mimimum;
    }

    private void AffichageMatrice(int[,] mat)
    {
        string s = "";
        int row = mat.GetLength(0);
        print(row);
        int col = mat.GetLength(1);
        print(col);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (i == position[0] && j == position[1])
                {
                    s += " X ";
                }
                else if(i == players.position.x && j == players.position.y)
                {
                    s += " P ";
                }
                else
                {
                    s += mat[i, j];
                }
            }
            s += "\n";
        }
        print(s);
        print("longueur matrice :" + mat.GetLength(0));

    }
    
}
