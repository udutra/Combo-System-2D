using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerCombo : MonoBehaviour
{
    private Animator anim;
    private bool startCombo, canHit, resetCombo;
    private float comboTimer;
    private Hit currentHit, nextHit;
    public Combo[] combos;
    public List<string> currentCombo;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        canHit = true;
    }

    private void Update()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {

        if((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && !canHit)
        {
            resetCombo = true;
        }

        for (int i = 0; i < combos.Length; i++)
        {

            if(combos[i].hits.Length > currentCombo.Count)
            {
                if (Input.GetButtonDown(combos[i].hits[currentCombo.Count].inputButton))
                {
                    if (currentCombo.Count == 0)
                    {
                        Debug.Log("Primeiro hit foi adicionado!");
                        PlayerHit(combos[i].hits[currentCombo.Count]);
                        break;
                    }
                    else
                    {
                        bool comboMatch = false;
                        for (int y = 0; y < currentCombo.Count; y++)
                        {
                            if (currentCombo[y] != combos[i].hits[y].inputButton)
                            {
                                Debug.Log("Input não pertence ao combo atual!");
                                comboMatch = false;
                                break;
                            }
                            else
                            {
                                comboMatch = true;
                            }
                        }
                        if (comboMatch && canHit)
                        {
                            Debug.Log("Hit adicionado ao combo!");
                            nextHit = combos[i].hits[currentCombo.Count];
                            canHit = false;
                            break;
                        }
                    }
                }
            }
        }

        if (startCombo)
        {
            comboTimer += Time.deltaTime;
            if (comboTimer >= currentHit.animationTime && !canHit)
            {
                PlayerHit(nextHit);
                if (resetCombo)
                {
                    canHit = false;
                    CancelInvoke();
                    Invoke("ResetCombo", currentHit.animationTime);
                }
            }
            if (comboTimer >= currentHit.resetTime)
            {
                ResetCombo();
            }
        }
    }

    private void PlayerHit(Hit hit)
    {
        comboTimer = 0;
        anim.Play(hit.animation);
        startCombo = true;
        currentCombo.Add(hit.inputButton);
        currentHit = hit;
        canHit = true;
    }

    private void ResetCombo()
    {
        startCombo = false;
        comboTimer = 0;
        currentCombo.Clear();
        anim.Rebind();
        canHit = true;
    }
}