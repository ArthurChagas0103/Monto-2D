using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacoes : MonoBehaviour
{
    bool noChao;
    Animator animacao;
    SpriteRenderer renderizador;
    // Start is called before the first frame update
    void Start()
    {
     noChao = true;   
     animacao = gameObject.GetComponent<Animator>();
     renderizador = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ControleAnimacoes();
    }

    void OnTriggerEnter2D(Collider2D colisor) {
        if(colisor.gameObject.CompareTag("Chao")) {
            noChao = true;
        } else {
            noChao = false;
        }
    }

    void ControleAnimacoes() {
        float sentido = Input.GetAxisRaw("Horizontal");
        if(noChao == true && sentido != 0) {
            
            animacao.SetBool("Correu", true);
            if(sentido < 0) {
                renderizador.flipX = true;
            } else if (sentido > 0) {
                renderizador.flipX = false;
            }

        }

        if(noChao == true && sentido == 0) {
            animacao.SetBool("Correu", false);
        }

    }
}
