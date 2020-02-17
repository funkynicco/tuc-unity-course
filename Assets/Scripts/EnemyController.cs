using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyController : MonoBehaviour
{
    private GameManager _gameManager;
    private Transform _startTransform;
    private AICharacterControl _ai;

    private FireControll _ignitingFire = null;
    private float _startIgnitingFire = 0.0f;

    private void Start()
    {
        _startTransform = GameObject.Find("EnemySpawn").transform;
        _gameManager = GameObject.Find("GameEngine").GetComponent<GameManager>();
        _ai = gameObject.GetComponent<AICharacterControl>();
    }

    public void RunToStart()
    {
        _ai.SetTarget(_startTransform);
    }

    public bool IsRunningToStart()
    {
        return _ai.target == _startTransform;
    }

    private void FixedUpdate()
    {
        if (_ignitingFire != null &&
            (Time.fixedTime - _startIgnitingFire) >= 3)
        {
            _ignitingFire.ResetFire();
            _ignitingFire = null;
            RunToStart();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Debug.Log($"Enemy triggered in fire");

            _ignitingFire = other.gameObject.GetComponent<FireControll>();
            _startIgnitingFire = Time.fixedTime;

            if (!_ignitingFire.IsBurnedOut)
            {
                _ignitingFire = null;
                RunToStart();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
        }
    }
}
