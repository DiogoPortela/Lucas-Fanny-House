using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterSpawn : MonoBehaviour
{

    public GameObject spawner;
    private static List<Transform> spawnPoints;

    public  GameObject enemyPrefab;
    private static GameObject enemyPrefabStatic;
    public static List<GameObject> enemies;

    public GameObject player;
    public GameObject parent;
    private static GameObject parentStatic;

    private void Start()
    {
        enemyPrefabStatic = enemyPrefab;
        parentStatic = parent;

        spawnPoints = new List<Transform>();
        enemies = new List<GameObject>();

        foreach (Transform t in spawner.GetComponentsInChildren<Transform>(false))
        {
            if(t != this.transform)
            {
                spawnPoints.Add(t);
            }
        }
    }

    public static void Spawn(int count = 1)
    {
        for(int i = 0; i < count; i++)
        {
            foreach (Transform t in spawnPoints)
            {
                enemies.Add(Instantiate(enemyPrefabStatic, t.position, t.rotation, parentStatic.transform));
            }
        }
    }

    public static void RemoveFromList(GameObject obj)
    {
        if (enemies.Contains(obj))
            enemies.Remove(obj);

    }

    private void Update()
    {
        foreach (GameObject enemy in enemies)
        {
            NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
            agent.SetDestination(player.transform.position);
        }
    }

}
