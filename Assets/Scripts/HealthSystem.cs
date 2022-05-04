using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    [SerializeField] Sprite fullHeart, emptyHeart;
    [SerializeField] Image life1, life2, life3;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //print("Player Vie" + Player.instance.GetLives());
        switch (Player.instance.GetLives())
        {
            case 3:
                life3.sprite = fullHeart;
                life2.sprite = fullHeart;
                life1.sprite = fullHeart;
                break;
            case 2:
                life3.sprite = emptyHeart;
                life2.sprite = fullHeart;
                life1.sprite = fullHeart;
                break;
            case 1:
                life3.sprite = emptyHeart;
                life2.sprite = emptyHeart;
                life1.sprite = fullHeart;
                break;
            case 0:
                life3.sprite = emptyHeart;
                life2.sprite = emptyHeart;
                life1.sprite = emptyHeart;
                break;

        }
    }
}
