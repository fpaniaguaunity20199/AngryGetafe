using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pajarraco : MonoBehaviour
{
    public float force;
    private Touch touch;
    private Vector2 posIni;
    private bool pajarracoPulsado = false;
    void Update()
    {
        Touch[] touches = Input.touches;
        if (touches.Length > 0)
        {
            touch = touches[0];
            //Hay un puntero al menos puesto en la pantalla
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Began();
                    break;
                case TouchPhase.Moved:
                    Moved();
                    break;
                case TouchPhase.Ended:
                    Ended();
                    break;
            }
        }
    }
    private void Began()
    {
        if (PulsandoSobreElPajarraco())
        {
            posIni = transform.position;
            pajarracoPulsado = true;
        }
    }
    private void Moved()
    {
        if (pajarracoPulsado)
        {
            transform.position = Camera.main.ScreenToWorldPoint(touch.position);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
    private void Ended()
    {
        if (pajarracoPulsado)
        {
            Vector2 posFinal = transform.position;
            Vector2 direccion = posIni - posFinal;
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().AddForce(direccion * force);
        }
    }
    private bool PulsandoSobreElPajarraco()
    {
        bool estaPulsado = false;
        Vector3 realTouchPos = Camera.main.ScreenToWorldPoint(touch.position);
        RaycastHit2D rch2d = Physics2D.Raycast(Camera.main.transform.position, realTouchPos-Camera.main.transform.position);
        if((rch2d.collider != null) && (rch2d.transform.gameObject.CompareTag("Player")))
        {
            estaPulsado = true;
        }
        return estaPulsado;
    }
}
