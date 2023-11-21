using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player1"))
        {
            animator.SetBool("isScared", true);
        }
        this.GetComponent<RandomNPCMovement>().enabled = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            animator.SetBool("isScared", false);
        }
        this.GetComponent<RandomNPCMovement>().enabled = true;
    }
}
