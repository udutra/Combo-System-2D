using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerCombo : MonoBehaviour
{
    public Combo[] combos;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {
        for (int i = 0; i < combos.Length; i++)
        {
            if (Input.GetButtonDown(combos[i].hits[0].inputbutton))
            {
                PlayerHit(combos[i].hits[0]);
                break;
            }
        }
    }

    private void PlayerHit(Hit hit)
    {
        anim.Play(hit.animation);
    }

    private void Reset()
    {
        
    }
}