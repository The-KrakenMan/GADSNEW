using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class CamAttach : MonoBehaviour
{
    public GameObject p1Head;
   
    CinemachineVirtualCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }
       

    // Update is called once per frame
    void Update()
    {
            cam.Follow = p1Head.transform; 
    }
}
