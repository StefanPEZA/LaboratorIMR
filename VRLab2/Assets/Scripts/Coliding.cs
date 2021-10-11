using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Coliding : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private UnityEvent onTriggerExit;

    private void Start()
    {
        if (onTriggerExit == null)
            onTriggerExit = new UnityEvent();
    }


    Vector3 spawnPoint = new Vector3(-5, 0.2f, -0.017f);
    IEnumerator Goal()
    { 
        yield return new WaitForSeconds(2);
        ball.transform.position = spawnPoint;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity= Vector3.zero;
    }

    void OnTriggerExit(Collider other)
    {
        StartCoroutine(Goal());
        onTriggerExit.Invoke();
        
    }
}
