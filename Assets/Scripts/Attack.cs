﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private int damage;
    private bool slowDown;
    private AudioClip hitSound;
    public AudioPlayer audioPlayer;

    public void SetAttack(Hit hit)
    {
        damage = hit.damage;
        slowDown = hit.slowDown;
        hitSound = hit.hitSound;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage enemy = other.GetComponent<Damage>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            audioPlayer.PlaySound(hitSound);
            if (slowDown)
            {
                SlowDown.instance.SetSlowDown();
            }
            ComboManager.instance.SetCombo();
        }
    }
}
