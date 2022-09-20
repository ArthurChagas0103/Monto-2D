using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamante : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D colisao){
        if(colisao.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            }
     }
     
}
