using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulo : MonoBehaviour
{
	private Rigidbody2D rb;
	int pulos = 2;

	void Start()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        Pular();
    }

    void Pular()
    {
		if(Input.GetButtonDown("Jump") && pulos > 0)
        {
			rb.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
            pulos--;
        }
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Ground"))
        {
            pulos = 2;
        }   
    }

}
