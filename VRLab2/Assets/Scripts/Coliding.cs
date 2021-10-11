using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coliding : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject ball;

    int score = 0;
    Vector3 spawnPoint = new Vector3(-5, 0.2f, -0.017f);
    IEnumerator Goal()
    { 
        score++;
        string str = text.text.Split(':')[1];
        text.text = text.text.Replace(str, " " + score.ToString());
        yield return new WaitForSeconds(2);
        ball.transform.position = spawnPoint;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity= Vector3.zero;
    }
    void OnTriggerExit(Collider other)
    {
        StartCoroutine(Goal());
        
    }
}
