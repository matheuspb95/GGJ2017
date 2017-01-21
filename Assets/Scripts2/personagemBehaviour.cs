using UnityEngine;
using System.Collections;

public class personagemBehaviour : MonoBehaviour {

    public Animator anime;
    public float velocidade;

	public bool praDireita;
	public bool praEsquerda;
	public bool praCima;
	public bool praBaixo;

    public int estado;

    enum estados { baixo, cima, esquerda, direita }

    // Use this for initialization
    void Start () {
        //velocidade = 4;
        anime = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.rotation = new Quaternion(0,0,0,0);

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movimente = new Vector2 (moveHorizontal, moveVertical);
		transform.Translate(movimente*velocidade*Time.deltaTime);

        if (moveVertical > 0)
        {
            praCima = true;
            estado = (int)estados.cima;
        }
        else
        {
            praCima = false;
        }

        if (moveVertical < 0)
        {
            praBaixo = true;
            estado = (int)estados.baixo;
        }
        else
        {
            praBaixo = false;
        }

        if (moveHorizontal < 0)
        {
            praEsquerda = true;
            estado = (int)estados.esquerda;
        }
        else
        {
            praEsquerda = false;
        }

        if (moveHorizontal > 0)
        {
            praDireita = true;
            estado = (int)estados.direita;
        }
        else
        {
            praDireita = false;
        }

        anime.SetInteger("estado", estado);
        anime.SetBool("cima", praCima);
        anime.SetBool("baixo", praBaixo);
        anime.SetBool("esquerda", praEsquerda);
        anime.SetBool("direita", praDireita);
    }
}
