using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 StartPosition;
    Quaternion StartRotation;
    ParticleSystem Water;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = gameObject.transform.position;
        StartRotation = gameObject.transform.rotation;
        Water = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Water.Play();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Water.Stop();
        }

        if (Input.GetMouseButtonDown(1))
        {
            var gameManager = GameObject.Find("GameEngine").GetComponent<GameManager>();
            foreach (var fire in gameManager.Fires)
            {
                for (int i = 0; i < 10; i++)
                {
                    fire.DamageFire();
                }
            }
        }
    }

    public void ResetPlayer()
    {
        gameObject.transform.SetPositionAndRotation(StartPosition, StartRotation);
    }


}
