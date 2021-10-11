using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField]
    private int score = 0;

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
        
    }
}
