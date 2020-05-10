using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimation : MonoBehaviour
{
    public AnimationClip replacibleAttackAnimation;

    public AnimationClip[] defaultAttackAnimSet;
    protected AnimationClip[] currentAttackAnimSet;
    private Dictionary<AnimationClip, float> animationDamageDelay;

    const float locomotionAnimationSmoothTime = 0.1f;

    protected Animator characterAnimator;
    NavMeshAgent navAgent;
    protected CharacterCombat combat;
    protected AnimatorOverrideController overrideController;

    protected virtual void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        characterAnimator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();

        overrideController = new AnimatorOverrideController(characterAnimator.runtimeAnimatorController);
        characterAnimator.runtimeAnimatorController = overrideController;

        currentAttackAnimSet = defaultAttackAnimSet;
        combat.OnAttack += OnAttack;
    }

    protected virtual void Update()
    {
        float speedPercent = navAgent.velocity.magnitude / navAgent.speed;
        characterAnimator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);

        characterAnimator.SetBool("inCombat", combat.inCombat);
    }

    protected virtual void OnAttack()
    {
        characterAnimator.SetTrigger("attack");
        int attackIndex = Random.Range(0, currentAttackAnimSet.Length);
        overrideController[replacibleAttackAnimation] = currentAttackAnimSet[attackIndex];
    }
}
