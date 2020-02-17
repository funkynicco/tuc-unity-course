using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControll : MonoBehaviour
{
    /*private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Water")
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
    } */

    public void PutOutFire()
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
