using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //[RequireComponent(typeof(BoxCollider2D))]
public class Jugador : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate(){

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reiniciar moveDelta
        moveDelta = new Vector3(x,y,0);

        // Cambiar de dirección sprite
        if(moveDelta.x > 0)

        // Vector3.one == new Vector3(1,1,1)
            transform.localScale =  Vector3.one;
        else if(moveDelta.x < 0)
            transform.localScale = new Vector3(-1,1,1);
        // Comprueba si es posible mover, si hay una caja, si retorna null, se mueve
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0 , new Vector2(0,moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Bloqueo"));
        if(hit.collider == null){
        // Movimiento en vertical
        transform.Translate(0, moveDelta.y * Time.deltaTime, 0);

        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0 , new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Bloqueo"));
        if(hit.collider == null){
        // Movimiento en horizontal
        transform.Translate( moveDelta.x * Time.deltaTime,0 , 0);

        }
    }
}
