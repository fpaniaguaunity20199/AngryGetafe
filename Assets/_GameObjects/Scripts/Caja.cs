using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    [SerializeField] float destructionSpeedLimit;
    [SerializeField] GameObject prefabScore;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude >= destructionSpeedLimit)
        {
            Instantiate(prefabScore, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
