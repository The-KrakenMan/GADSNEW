using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kys : MonoBehaviour
{

    float Timer = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer = Timer - Time.fixedDeltaTime;
        Debug.Log(Timer.ToString());
        if (Timer < 0)
        {
            Destroy(this.gameObject);
        }


    }
}
