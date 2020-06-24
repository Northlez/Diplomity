using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    NavMeshAgent agent;
    PlayerController controller;
    Animator animator;
    CharacterCombat combat;
    CapsuleCollider collider;

    HealthBarScript healthBar;
    public bool playerIsAlive = true;
    public GameObject deathScreenPanel;
    public GameObject player;

    public void Start()
    {
        agent = player.GetComponent<NavMeshAgent>();
        controller = player.GetComponent<PlayerController>();
        animator = player.GetComponentInChildren<Animator>();
        combat = player.GetComponent<CharacterCombat>();
        collider = player.GetComponent<CapsuleCollider>();

        healthBar = healthBar = FindObjectOfType<HealthBarScript>();
    }

    public void KillPlayer()
    {
        playerIsAlive = false;
        collider.enabled = false;
        agent.enabled = false;
        controller.enabled = false;
        animator.enabled = false;
        combat.enabled = false;
        deathScreenPanel.SetActive(true);
    }

    public void Heal(int healing)
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.Heal(healing);
        healthBar.SetHealth(playerStats.currentHealth);
    }

}
