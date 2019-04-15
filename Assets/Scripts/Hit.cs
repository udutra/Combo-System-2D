using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Hit
{
    public string animation, inputbutton;
    public float animationTime, resetTime;
    public int damage;
    public AudioClip hitSound;
    public bool slowDown;
}