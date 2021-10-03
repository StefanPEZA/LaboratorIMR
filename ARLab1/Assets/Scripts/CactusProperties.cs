using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusProperties : MonoBehaviour
{
    public bool IsSpawned;

    public void OnSpawn() 
    {
        IsSpawned = true;
    }
    public void OnDespawn() 
    {
        IsSpawned = false;
    }

    public void LookAtMy(Transform focus)
    {
        Vector3 relativePos = focus.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 10f * Time.deltaTime);
    }
}
