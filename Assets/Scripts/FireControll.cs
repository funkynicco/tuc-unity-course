using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControll : MonoBehaviour
{
    public int Health = 10;

    public bool IsBurnedOut => Health == 0;

    private bool _isBeingDamaged = false;
    private float _damageTimeCounter = 0.0f;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameEngine").GetComponent<GameManager>();
    }

    private void Update()
    {
        _damageTimeCounter += Time.fixedDeltaTime;
        if (_damageTimeCounter >= 0.4f)
        {
            if ((_isBeingDamaged && Input.GetMouseButton(0)) ||
                _gameManager.SimulateFiresBurningOut)
                DamageFire();

            _damageTimeCounter -= 0.4f;
        }
    }

    public void DamageFire() // damages the fire by 1 damage point
    {
        if (Health == 0)
            return; // Fire is already dead

        Health--;
        if (Health == 0)
        {
            ParticleSystem[] particleSystem = GetComponentsInChildren<ParticleSystem>();

            foreach (var ps in particleSystem)
            {
                if (ps.gameObject.tag != "Smoke")
                {
                    ps.Stop();
                }
            }

            Light light = GetComponentInChildren<Light>();
            light.enabled = false;
        }
    }

    public void ResetFire()
    {
        Health = 10;
        ParticleSystem[] particleSystem = GetComponentsInChildren<ParticleSystem>();

        foreach (var ps in particleSystem)
        {
            if (ps.gameObject.tag != "Smoke")
            {
                ps.Play();
            }
        }

        Light light = GetComponentInChildren<Light>();
        light.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //ResetFire();
        }
        else if (other.gameObject.tag == "Water")
        {
            _isBeingDamaged = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            _isBeingDamaged = false;
        }
    }
}
