using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField]
    private GameManger manager;

    IEnumerator Respawn(GameObject ball)
    {
        yield return new WaitForSeconds(2);
        manager.RespawnBall(ball);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("aha");
        StartCoroutine(Respawn(other.gameObject));
    }
}