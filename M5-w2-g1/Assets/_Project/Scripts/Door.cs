using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PointAndClick>(out var t))
        {
            animator.SetBool("Open", true);
        }
  
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PointAndClick>(out var t))
        {
            animator.SetBool("Open", false);
        }
    }
}
