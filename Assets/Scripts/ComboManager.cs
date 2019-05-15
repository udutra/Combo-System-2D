using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    private Animator comboTextAnimator;
    private int totalCombo;
    public static ComboManager instance;
    public Text comboText;
    public float resetTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        comboTextAnimator = comboText.GetComponent<Animator>();
    }

    public void SetCombo()
    {
        totalCombo++;
        comboText.text = "x" + totalCombo;
        comboTextAnimator.SetTrigger("Hit");

        CancelInvoke();
        Invoke("ResetCombo", resetTime);
    }

    private void ResetCombo()
    {
        totalCombo = 0;
    }
}
