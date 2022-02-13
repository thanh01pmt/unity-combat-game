using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTree : MonoBehaviour
{
    [SerializeField] Animator treeAnimator = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        treeAnimator.SetBool("Shake", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        treeAnimator.SetBool("Shake", false);
    }
}
