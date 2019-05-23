using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public bool facingRight;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right* h * speed * Time.deltaTime);

        if(facingRight && h < 0)
        {
            Flip();
        }
        else if(!facingRight && h > 0)
        {
            Flip();
        }

        anim.SetFloat("Speed", Mathf.Abs(h));
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale; 
    }
}
