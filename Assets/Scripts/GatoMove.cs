using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoMove : MonoBehaviour
{
    public float speed, flipTime;

    private void Start()
    {
        InvokeRepeating("Flip", flipTime, flipTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void Flip()
    {
        speed *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
