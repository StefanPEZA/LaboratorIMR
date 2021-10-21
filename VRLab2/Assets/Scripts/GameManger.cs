using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField]
    private int score = 0;

    [SerializeField]
    private GameObject ball;

    public TextMeshPro scoreObject;
    public Transform spawnPoint;

    public void RespawnBall(GameObject ball)
    {
        if (ball == this.ball)
        {
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ball.transform.position = spawnPoint.position;
        }
    }

    public void ResetScore()
    {
        this.score = 0;
    }

    public void Increment()
    {
        this.score++;
    }

    // Update is called once per frame
    void Update()
    {
        this.scoreObject.SetText(string.Format("{0:000}", this.score));
    }
}
