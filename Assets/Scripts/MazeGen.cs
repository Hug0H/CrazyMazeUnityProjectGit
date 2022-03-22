﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeGen : MonoBehaviour
{
    //matrice 0= vide || 1= mur
    public int[,] matrice;
    private int[,] matriceVisite;
    int currentI;
    int currentJ;
    Stack<(int, int)> pile = new Stack<(int, int)>();


    private Vector3 groudSize; // valeur possible : 5n -1  
    private int sizeCellule;

    private void AffichageMatrice(int[,] mat)
    {

        string s = "";
        int row = mat.GetLength(0);
        int col = mat.GetLength(1);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                s += mat[i, j];
            }
            s += "\n";

        }

        //print(s);
        //print("longueur matrice :" + mat.GetLength(0));
    }
    // Start is called before the first frame update
    public void Start()
    {
        //setup de valeur importante
        sizeCellule = 2;
        groudSize = transform.localScale;

        //Initialisation de la matrice rempli
        matrice = new int[(int)groudSize.x, (int)groudSize.y];
        int tailleX = matrice.GetLength(0);
        int tailleY = matrice.GetLength(1);
        for (int i = 0; i < tailleX; i++)
        {
            for (int j = 0; j < tailleY; j++)
            {

                matrice[i, j] = 0;
            }
        }
        //initialisation les bordures
        for (int i = 0; i < tailleX; i++)
        {
            for (int j = 0; j < tailleY; j++)
            {
                if (i == 0 || i == tailleX - 1 || j == 0 || j == tailleY - 1)
                {
                    matrice[i, j] = 1;

                }
                if (i % sizeCellule == 0 || j % sizeCellule == 0)
                {
                    matrice[i, j] = 1;
                }
            }

        }
        AffichageMatrice(matrice);

        //matrice des visites
        matriceVisite = new int[(int)groudSize.x / sizeCellule, (int)groudSize.y / sizeCellule];
        //Initialisation de la matrice booléenne
        int tailleVisiteX = matriceVisite.GetLength(0);
        int tailleVisiteY = matriceVisite.GetLength(1);
        for (int i = 0; i < tailleVisiteX; i++)
        {
            for (int j = 0; j < tailleVisiteY; j++)
            {
                matriceVisite[i, j] = 0;
            }
        }
        //print("--------------------------------------------------------------------------------");
        AffichageMatrice(matriceVisite);

        //On suit la page wikipedia https://fr.wikipedia.org/wiki/Modélisation_mathématique_d%27un_labyrinthe
        //On choisit arbitrairement une cellule, on stocke la position en cours et on la marque comme visitée (vrai).
        currentI = Random.Range(0, tailleVisiteX);
        //print(currentI);
        currentJ = Random.Range(0, tailleVisiteY);
        //print(currentJ);
        matriceVisite[currentI, currentJ] = 1;
        pile.Push((currentI, currentJ));
        GenLab();

    }
    void GenLab()
    {
        while (pile.Count != 0)
        {
            int interI = currentI * sizeCellule + 1;
            //print("InterI : " + interI);
            int interJ = currentJ * sizeCellule + 1;
            //print("InterJ : " + interJ);
            //print("InterI,InterJ : " + matrice[interI, interJ]);
            //Puis on regarde quelles sont les cellules voisines possibles et non visitées.
            int celluleHaut;
            int celluleDroite;
            int celluleBas;
            int celluleGauche;
            try
            {
                celluleHaut = matriceVisite[currentI - 1, currentJ];
            }
            catch (System.IndexOutOfRangeException e)
            {
                celluleHaut = 1;
            }
            try
            {
                celluleBas = matriceVisite[currentI + 1, currentJ];
            }
            catch (System.IndexOutOfRangeException e)
            {
                celluleBas = 1;
            }
            try
            {
                celluleGauche = matriceVisite[currentI, currentJ - 1];
            }
            catch (System.IndexOutOfRangeException e)
            {
                celluleGauche = 1;
            }
            try
            {
                celluleDroite = matriceVisite[currentI, currentJ + 1];
            }
            catch (System.IndexOutOfRangeException e)
            {
                celluleDroite = 1;
            }
            ////print("cell droite:"  +celluleDroite);
            ////print("cell gauche:" + celluleGauche);
            ////print("cell haut:" + celluleHaut);
            ////print("cell bas:" + celluleBas);

            string[] choixPossibles = new string[4];
            int compteur = 0;

            if (celluleHaut == 0)
            {
                choixPossibles[compteur] = "haut";
                compteur += 1;
            }
            if (celluleBas == 0)
            {
                choixPossibles[compteur] = "bas";
                compteur += 1;
            }
            if (celluleGauche == 0)
            {
                choixPossibles[compteur] = "gauche";
                compteur += 1;
            }
            if (celluleDroite == 0)
            {
                choixPossibles[compteur] = "droite";
                compteur += 1;
            }

            //S'il y a au moins une possibilité, on en choisit une au hasard, on ouvre le mur et on recommence avec la nouvelle cellule
            if (compteur != 0)
            {
                int choix = Random.Range(0, compteur);
                string result = choixPossibles[choix];
                //print("resultat aleatoire : " + result);
                if (result == "droite")
                {
                    currentJ += 1;
                    matriceVisite[currentI, currentJ] = 1;


                    //Il faut ouvrir le mur ! 
                    //De base on es en haurt à gauche de chaque case !!!!
                    for (int i = 0; i < sizeCellule - 1; i++)
                    {
                        //interY += 1;
                        matrice[interI + i, interJ + sizeCellule - 1] = 0;
                    }
                }
                else if (result == "gauche")
                {
                    currentJ -= 1;
                    matriceVisite[currentI, currentJ] = 1;

                    //Il faut ouvrir le mur ! 
                    for (int i = 0; i < sizeCellule - 1; i++)
                    {
                        //interY -= 1;
                        matrice[interI + i, interJ - 1] = 0;
                    }

                }
                else if (result == "haut")
                {
                    currentI -= 1;
                    matriceVisite[currentI, currentJ] = 1;

                    //Il faut ouvrir le mur ! 
                    for (int i = 0; i < sizeCellule - 1; i++)
                    {
                        //interX -= 1;
                        matrice[interI - 1, interJ + i] = 0;

                    }
                }
                else if (result == "bas")
                {
                    currentI += 1;
                    matriceVisite[currentI, currentJ] = 1;

                    //Il faut ouvrir le mur ! 
                    for (int i = 0; i < sizeCellule - 1; i++)
                    {
                        //interX += 1;
                        matrice[interI + sizeCellule - 1, interJ + i] = 0;
                    }
                }
                pile.Push((currentI, currentJ));
                AffichageMatrice(matrice);
                //print("-----------------------------------------------------------");
                AffichageMatrice(matriceVisite);
            }
            //S'il n'y en pas, on revient à la case précédente et on recommence.
            else
            {
                (currentI, currentJ) = pile.Pop();
            }
            GenLab();
        }
    }
}