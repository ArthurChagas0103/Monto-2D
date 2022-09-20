using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
	private Rigidbody2D rb;
	public Vector2 direcaoDoPulo = new Vector3(0, 1);
	private float movimentoHorizontal, forca = 0.2f, velocidade = 3f;  //Movimento Horizontal = Se o personagem irá andar para a direita ou esquerda (sendo -1 para a esquerda e 1 para a direita, 0 sem movimento)
	private bool movimentoVertical, personagemChao, personagemPula1, personagemPula2, personagemPodePular;
	public float distanciaDoChao = 1, forcaDoPulo = 7, tempoPorPulo = 1;

	// Start is called before the first frame update
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		movimentoHorizontal = 0;
		movimentoVertical = false;
		personagemPula1 = personagemPula2 = false;
		personagemPodePular = true;
	}

	// FixedUpdate é chamado em intervalos fixos
	void FixedUpdate()
	{
		MovimentoForca();
	}

	void MovimentoForca() // Função de caminhada aplicando força ao objeto
	{
		movimentoHorizontal = Input.GetAxisRaw("Horizontal"); //Pega um valor (1, -1 ou 0) quando o jogador aperta uma das teclas de andar para frente ou para trás	
		Debug.Log(movimentoHorizontal);
		rb.AddForce(new Vector2(forca * movimentoHorizontal, 0), ForceMode2D.Impulse);
	}

	void MovimentoVelocidade() // Função de caminhada alterando a velocidade do objeto
	{
		movimentoHorizontal = Input.GetAxisRaw("Horizontal");
		Debug.Log(movimentoHorizontal);
		rb.velocity = new Vector2(velocidade * movimentoHorizontal, rb.velocity.y);
	}

	void MovimentoPosicao() // Função de caminhada transformando a posição do objeto
	{
		movimentoHorizontal = Input.GetAxisRaw("Horizontal");
		transform.position = transform.position + new Vector3(velocidade * Time.deltaTime * movimentoHorizontal, 0, 0); //Posição = Posição Atual + Distância Percorrida (Velocidade x Tempo x Direção)
	}

	void Update()
    {
		Pulo();
    }

	void Pulo()
    {
		movimentoVertical = Input.GetButtonDown("Jump");
		personagemChao = Physics2D.Linecast(transform.position, transform.position - Vector3.up * distanciaDoChao);

		if ((personagemPula1 == true || personagemPula2 == true) && personagemChao == true)
		{
			personagemPula1 = personagemPula2 = false;
		}
		if (movimentoVertical == true && personagemChao == false)
		{
			personagemPula1 = true;
		}
		if (movimentoVertical == true && personagemChao == true && personagemPula1 == false && personagemPula2 == false && personagemPodePular == true)
		{
			StartCoroutine("TempoDePulo");
			personagemPula1 = true;
			personagemPula2 = false;
			rb.AddForce(direcaoDoPulo * forcaDoPulo, ForceMode2D.Impulse);
		}
		if (movimentoVertical == true && personagemChao == false && personagemPula1 == true && personagemPula2 == false && personagemPodePular == true)
		{
			StartCoroutine("TempoDePulo");
			personagemPula1 = true;
			personagemPula2 = true;
			rb.AddForce(direcaoDoPulo * forcaDoPulo * 2, ForceMode2D.Impulse);
		}
	}
	IEnumerator TempoDePulo()
	{
		personagemPodePular = false;
		yield return new WaitForSeconds(tempoPorPulo);
		personagemPodePular = true;
	}
}
