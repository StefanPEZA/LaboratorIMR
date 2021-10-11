using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Coliding : MonoBehaviour
{
    [SerializeField]
    private GameManger manager;

    [SerializeField]
    private UnityEvent onTriggerExit;

    private ParticleSystem effect;

    private void Start()
    {
        if (onTriggerExit == null)
            onTriggerExit = new UnityEvent();
        effect = GetComponentInChildren<ParticleSystem>();
    }

    IEnumerator Goal(GameObject ball)
    {
        effect.Play();
        yield return new WaitForSeconds(2);
        effect.Stop();
        manager.RespawnBall(ball);
    }

    void OnTriggerExit(Collider other)
    {
        StartCoroutine(Goal(other.gameObject));
        onTriggerExit.Invoke();
    }
}
