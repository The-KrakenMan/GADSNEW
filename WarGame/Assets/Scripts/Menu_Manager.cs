using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Menu_Manager : MonoBehaviour
{
    public int NumOfPlayers;
    public TextMeshProUGUI Output;
    public GameObject WaitingForPlayers;
    public GameObject RoleSelect;
    public GameObject p1PicSoldier;
    public GameObject p1PicRefugee;
    public GameObject p2PicSoldier;
    public GameObject p2PicRefugee;
    public GameObject btnEnlist;
    public GameObject btnContinue;
    public Game_Manager GameMan;


    // Start is called before the first frame update
    void Start()
    {
        GameMan = FindObjectOfType<Game_Manager>(); 
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   
    public void PlayerJoined()
    {
        NumOfPlayers++;
        Output.text = NumOfPlayers.ToString();
        if (NumOfPlayers > 1)
        {
            ChooseRoles();
            WaitingForPlayers.SetActive(false);
        }
    }

    public void ChooseRoles()
    {
        RoleSelect.SetActive(true);
    }
    
    public void Enlist()
    {
        btnEnlist.SetActive(false);
        btnContinue.SetActive(true);

        int i = UnityEngine.Random.Range(0, 10);
        if (i % 2 == 0)
        {
            p1PicSoldier.SetActive(true);
            p2PicRefugee.SetActive(true);
            Game_Manager.GameState = 1;
        }
        else
        {
            p2PicSoldier.SetActive(true);
            p1PicRefugee.SetActive(true);
            Game_Manager.GameState = 2;
        }
    }
}
