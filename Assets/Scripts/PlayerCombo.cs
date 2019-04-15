using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerCombo : MonoBehaviour
{
    private Animator anim;
    private bool startCombo;
    public Combo[] combos;
    public List<string> currentCombo;
    
    

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

            if(combos[i].hits.Length > currentCombo.Count)
            {
                if (Input.GetButtonDown(combos[i].hits[currentCombo.Count].inputbutton))
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
                            if (currentCombo[y] != combos[i].hits[y].inputbutton)
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
                        if (comboMatch)
                        {
                            Debug.Log("Hit adicionado ao combo!");
                            PlayerHit(combos[i].hits[currentCombo.Count]);
                            break;
                        }
                    }
                }
            }
        }
    }

    private void PlayerHit(Hit hit)
    {
        anim.Play(hit.animation);
        startCombo = true;
        currentCombo.Add(hit.inputbutton);
    }

    private void Reset()
    {
        startCombo = false;
    }
}