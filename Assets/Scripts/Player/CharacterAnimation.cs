using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimation : MonoBehaviour
{
    const float locomotionAnimationSmoothTime = 0.1f;

    Animator characterAnimator;
    NavMeshAgent navAgent;
    
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        characterAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float speedPercent = navAgent.velocity.magnitude / navAgent.speed;
        characterAnimator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
    }
}
