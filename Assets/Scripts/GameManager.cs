using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class GameManager : MonoBehaviour
{
    public Transform Spawn;
    public GameObject Enemy;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 3);
    }

    void SpawnEnemy()
    {
        var enemy = Instantiate(Enemy, Spawn);
        enemy.GetComponent<AICharacterControl>().SetTarget(Player.transform);
    }

}
