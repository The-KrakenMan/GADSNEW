using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMan : MonoBehaviour
{
    float Timer = 15;
    public GameObject Goals;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer = Timer - Time.fixedDeltaTime;
        if (Timer < 0)
        {
            Goals.SetActive(false);
        }

      
    }


}
