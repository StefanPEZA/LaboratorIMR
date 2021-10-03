using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnCactus : MonoBehaviour
{
    [SerializeField]
    private GameObject cactus1;

    [SerializeField]
    private GameObject cactus2;

    [SerializeField]
    private float fightDistance = 0.05f;

    public Camera arCamera;
    private CactusProperties cactus1Props;
    private CactusProperties cactus2Props;
    private Animator cactus1Animator;
    private Animator cactus2Animator;

    // Start is called before the first frame update
    void Start()
    {
        cactus1Props = cactus1.GetComponent<CactusProperties>();
        cactus2Props = cactus2.GetComponent<CactusProperties>();
        cactus1Animator = cactus1.GetComponent<Animator>();
        cactus2Animator = cactus2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cactus1Props.IsSpawned && cactus2Props.IsSpawned) 
        {
            HandleBothCactusSpawned();
        }
        else
        {
            HandleOneCactusDespawn();
        }
    }

    private void FixedUpdate()
    {
        if (cactus1Props.IsSpawned && cactus2Props.IsSpawned)
        {
            cactus1Props.LookAtMy(cactus2.transform);
            cactus2Props.LookAtMy(cactus1.transform);
        }
    }

    private float currentDistance;
    private void HandleBothCactusSpawned()
    {
        currentDistance = Vector3.Distance(cactus1.transform.position, cactus2.transform.position);
        if (currentDistance <= fightDistance)
        {
            SetBoolAnimatorParameter("IsFighting", true);
        }
        else
        {
            SetBoolAnimatorParameter("IsFighting", false);
        }
    }

    private void HandleOneCactusDespawn()
    {
        SetBoolAnimatorParameter("IsFighting", false);
        cactus1Props.LookAtMy(arCamera.transform);
        cactus2Props.LookAtMy(arCamera.transform);
    }

    private void SetBoolAnimatorParameter(string name, bool value)
    {
        cactus1Animator.SetBool(name, value);
        cactus2Animator.SetBool(name, value);
    }
}
