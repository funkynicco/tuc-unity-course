using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class GameManager : MonoBehaviour
{
    public int MaxEnemies = 5;
    public bool SimulateFiresBurningOut = false;

    public Transform Spawn;
    public GameObject Enemy;
    public GameObject Player;

    public List<FireControll> Fires;

    private List<GameObject> _enemies = new List<GameObject>();


    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1, 3);
        InvokeRepeating(nameof(SetEnemyTargets), 1, 1);
    }

    void SpawnEnemy()
    {
        if (_enemies.Count >= MaxEnemies)
            return;

        var enemy = Instantiate(Enemy, Spawn);
        //enemy.GetComponent<AICharacterControl>().SetTarget(Player.transform);
        _enemies.Add(enemy);
    }

    public void GameWin()
    {

    }

    public void GameOver()
    {
        Player.GetComponent<PlayerController>().ResetPlayer();

        foreach (var fire in Fires)
        {
            fire.ResetFire();
        }

        foreach (var enemy in _enemies)
        {
            Destroy(enemy);
        }

        _enemies.Clear();
    }

    public void SetEnemyTargets()
    {
        var burnedOutFires = new List<FireControll>();
        foreach (var fire in Fires)
        {
            if (fire.IsBurnedOut)
                burnedOutFires.Add(fire);
        }

        foreach (var enemy in _enemies)
        {
            if (burnedOutFires.Count == 0)
                break;

            var enemyController = enemy.GetComponent<EnemyController>();

            var ai = enemy.GetComponent<AICharacterControl>();
            if (ai.target != null &&
                !enemyController.IsRunningToStart())
                continue;

            var fireIndex = Random.Range(0, burnedOutFires.Count);

            ai.SetTarget(burnedOutFires[fireIndex].transform);
            burnedOutFires.RemoveAt(fireIndex);
        }
    }
}
