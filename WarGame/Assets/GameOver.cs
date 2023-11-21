using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject Win;
    public GameObject Lose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player2")
        {
            RefugeeWin();
        }
    }

    public void RefugeeWin()
    {
        Win.SetActive(true);
    }

    public void SoldierWin()
    {
        Lose.SetActive(true);
    }
}
