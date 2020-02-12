using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 StartPosition;
    Quaternion StartRotation;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = gameObject.transform.position;
        StartRotation = gameObject.transform.rotation;
    }

    public void ResetPlayer()
    {
        gameObject.transform.SetPositionAndRotation(StartPosition, StartRotation);
    }


}
