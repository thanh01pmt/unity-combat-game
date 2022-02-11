using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class LoopAnimScript : MonoBehaviour
{
    [SerializeField] AnimationClip loopClip;
    [SerializeField] Animator animator;
    void Awake()
    {
        if (animator)
        {
            if (loopClip)
            {
                AnimationClipSettings settings = AnimationUtility.GetAnimationClipSettings(loopClip);
                settings.loopTime = true;
                AnimationUtility.SetAnimationClipSettings(loopClip, settings);
                Debug.Log(loopClip.name);
                Debug.Log(loopClip.isLooping);
                animator.Play(loopClip.name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
