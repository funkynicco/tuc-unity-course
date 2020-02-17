using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "Fire")
        {
            other.GetComponent<FireControll>().PutOutFire();
        }
    }
}
