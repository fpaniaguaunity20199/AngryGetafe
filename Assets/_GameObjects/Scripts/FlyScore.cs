using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScore : MonoBehaviour
{
    [SerializeField] float verticalSpeed;
    [SerializeField] float alphaSpeed;
    Color colorBase;
    float alpha;
    private void Start()
    {
        colorBase = GetComponent<SpriteRenderer>().color;
        alpha = colorBase.a;
    }
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * verticalSpeed);
        GetComponent<SpriteRenderer>().color = new Color(colorBase.r, colorBase.g, colorBase.b, alpha);
        alpha = alpha - alphaSpeed;
        if (alpha<=0)
        {
            Destroy(gameObject);
        }
    }
}
