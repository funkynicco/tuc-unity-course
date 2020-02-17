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
        if(Input.GetMouseButtonDown(0))
        {
            Water.Play();
        } else if (Input.GetMouseButtonUp(0))
        {
            Water.Stop();
        }
    }

    public void ResetPlayer()
    {
        gameObject.transform.SetPositionAndRotation(StartPosition, StartRotation);
    }


}
