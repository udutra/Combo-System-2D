using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public int life;
    public Color defaultColor, damageColor;
    public float damageTime;
    public GameObject damageText;
    public Transform damageTextPosition;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        spriteRenderer.color = damageColor;
        Invoke("ReleaseDamage", damageTime);
        GameObject newDamageText = Instantiate(damageText, damageTextPosition.position, Quaternion.identity);
        newDamageText.GetComponentInChildren<Text>().text = damage.ToString();
        Destroy(newDamageText, 1);

    }

    private void ReleaseDamage()
    {
        spriteRenderer.color = defaultColor;
    }
}
