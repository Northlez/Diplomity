using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public string id;

    Enemy interaction;
    EnemyController controller;
    CharacterCombat combat;
    Animator animator;

    private void Awake()
    {
        interaction = GetComponent<Enemy>();
        controller = GetComponent<EnemyController>();
        combat = GetComponent<CharacterCombat>();
        animator = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
    }

    public override void Die()
    {
        interaction.enabled = false;
        controller.enabled = false;
        combat.enabled = false;
        animator.enabled = false;
    }
}
