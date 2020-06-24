using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDataHandler : MonoBehaviour
{
    static GameObject[] enemies;

    public static List<EnemiesData> SaveEnemiesData()
    {

        List<EnemiesData> enemiesData = new List<EnemiesData>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(var enemy in enemies)
        {
            EnemiesData enemyData = new EnemiesData();
            EnemyStats stats = enemy.GetComponent<EnemyStats>();
            
            enemyData.id = stats.id;
            enemyData.currentHealth = stats.currentHealth;
            enemyData.position = enemy.transform.position;
            enemyData.rotation = enemy.transform.rotation;
            enemiesData.Add(enemyData);
        }
        return enemiesData;
    }

    public static void LoadEnemiesData(List<EnemiesData> enemiesData)
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            foreach (var enemyData in enemiesData)
            {
                if (enemyData.id == enemy.GetComponent<EnemyStats>().id)
                {
                    EnemyStats stats = enemy.GetComponent<EnemyStats>();
                    NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();

                    agent.enabled = false;
                    enemy.transform.position = enemyData.position;
                    enemy.transform.rotation = enemyData.rotation;
                    agent.enabled = true;
                    stats.SetCurrentHealth(enemyData.currentHealth);
                    if (stats.currentHealth <= 0) stats.Die();
                }
            }
        }
    }
}
