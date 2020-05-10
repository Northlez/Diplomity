﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    const float combatCooldown = 5f;
    float lastAttackTime;

    public float damageAfterAttackDelay = .6f;

    public bool inCombat { get; private set; }
    public event System.Action OnAttack;

    CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (Time.time - lastAttackTime > combatCooldown)
        {
            inCombat = false;
        }
    }

    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, damageAfterAttackDelay));

            if (OnAttack != null)
                OnAttack();

            attackCooldown = 1f / attackSpeed;
            inCombat = true;
            lastAttackTime = Time.time;
        }
    }

    IEnumerator DoDamage (CharacterStats stats, float delay)
    {
       yield return new WaitForSeconds(delay);

       stats.TakeDamage(myStats.damage.GetValue());
        if (stats.currentHealth <= 0)
        {
            inCombat = false;
        }
    }
}
