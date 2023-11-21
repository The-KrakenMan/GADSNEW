using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //if GameState 1, then p1 Soldier, if GameState 2 then p2 Soldier
    public static int GameState;
    public static int PlayersSpawned = 0;

    public static int Player1HP = 10;
    public static int Player2HP = 10;

    public GameObject Player1;
    public GameObject Player2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1HP < 0)
        {
            this.GetComponent<GameOver>().RefugeeWin();
        }
        if (Player2HP < 0)
        {
            this.GetComponent<GameOver>().SoldierWin();
        }
    }
 
}
