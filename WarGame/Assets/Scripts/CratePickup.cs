using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CratePickup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject p1AkAmmo;
    public GameObject p2AkAmmo;
    public GameObject p1RPGAmmo;
    public GameObject p2RPGAmmo;
    public GameObject p1SniperAmmo;
    public GameObject p2SniperAmmo;

    public GameObject p2AkPickup;
    public GameObject p2SniperPickup;
    public GameObject p2RPGPickup;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.tag == ("Player1"))
          {
               int random = Random.Range(0, 3);
                 AmmoPickup(random, 1);
          }
             else
             {
            Debug.Log("We here");
                 int random = Random.Range(0, 2);
                if (random == 0)
                {//gunpickup
                    int randomgun = Random.Range(0, 3);
                    if (PlayerManager.p2Guns[randomgun])
                {
                    AmmoPickup(randomgun, 2);
                }
                else
                {
                   PlayerManager.p2Guns[randomgun] = true;
                    switch (randomgun)
                    {
                        case 0:
                            p2AkPickup.SetActive(true);
                            break;
                        case 1:
                            p2RPGPickup.SetActive(true);
                            break;
                        case 2:
                            p2SniperPickup.SetActive(true);
                            break;
                    }
                }
              
                }
                 else
                  {
                int randomgun = Random.Range(0, 3);
                AmmoPickup(randomgun, 2);
                 }
             }
         Destroy(this.gameObject);
    }   

    public void AmmoPickup(int Type, int Player)
    {
        switch (Type)
        {
            case 0 :
                {
                    if (Player == 1)
                    {
                        PlayerManager.p1AKAmmo = PlayerManager.p1AKAmmo + 10;
                        p1AkAmmo.SetActive(true);
                    }
                    else
                    {
                        PlayerManager.p2AKAmmo = PlayerManager.p2AKAmmo + 10;
                        p2AkAmmo.SetActive(true);
                    }
                }
                break;
            case 1:
                {
                    if (Player == 1)
                    {
                        PlayerManager.p1RPGAmmo = PlayerManager.p1RPGAmmo + 2;
                        p1RPGAmmo.SetActive(true);
                    }
                    else
                    {
                        PlayerManager.p2RPGAmmo = PlayerManager.p2RPGAmmo + 2;
                        p2RPGAmmo.SetActive(true);
                    }
                }
                break;

            case 2:
                {
                    if (Player == 1)
                    {
                        PlayerManager.p1SniperAmmo = PlayerManager.p1SniperAmmo + 5;
                        p1SniperAmmo.SetActive(true);
                    }
                    else
                    {
                        PlayerManager.p2SniperAmmo = PlayerManager.p2SniperAmmo + 5;
                        p2SniperAmmo.SetActive(true);
                    }
                }
                break;
        }
    }
    
}
