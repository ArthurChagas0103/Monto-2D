using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    int pontuacao;
    public string nomeA;
    string Estudante;

    void Start() {
        pontuacao = 0;
        //Estudante = gameObject.GetComponent <Prova>().seuNome;
    }

    string NomeAluno(string nome) {
        return nome;
    } 

    void OnCollisionEnter2D(Collision2D colisao) {
        bool diamante = colisao.gameObject.CompareTag("Diamante");
        
        if(diamante == true) {
            pontuacao = pontuacao + 1;
            print("Pontuação: " + pontuacao);
        }           
    }

    void OnTriggerEnter2D(Collider2D colisor) {
        bool fim = colisor.gameObject.CompareTag("Finish");

        if(fim == true && pontuacao >= 20) {
            print(Estudante + " terminou! Parabéns! :)");
        }
    }
}
