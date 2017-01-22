using UnityEngine;
using System.Collections;

public class segurancaBehaviour : MonoBehaviour
{
    public Animator anime;
    private float olhandox;
    private float olhandoy;
    public enum estados {cima, baixo, direita, esquerda }
    public estados olhar;
    public Transform personagem;
    private Vector2 alvo;
	public bool moving;
	LifeController life;
    public float velocity;
    private 
    // Use this for initialization
    void Start()
    {
		moving = true;
        personagem = GameObject.FindGameObjectWithTag("Player").transform;
		life = GetComponent<LifeController> ();
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        
		if (moving) {
            float distance = Vector2.Distance(personagem.position, transform.position);
            if (distance > 0.5f){
				alvo = personagem.transform.position;
				transform.position = Vector3.MoveTowards (transform.position, alvo, velocity * Time.deltaTime);
			}else {
				alvo = personagem.transform.position;
				transform.position = Vector3.MoveTowards (transform.position, alvo, velocity * Time.deltaTime * distance);
			}
            olhandox = personagem.position.x - transform.position.x;
            olhandoy = personagem.position.y - transform.position.y;
            if (Mathf.Abs(olhandoy) > Mathf.Abs(olhandox))
            {
                if (olhandoy > 0)
                {
                    olhar = estados.cima;
                }
                else
                {
                    olhar = estados.baixo;
                }
            }
            else
            {
                if (olhandox > 0)
                {
                    olhar = estados.direita;
                }
                else
                {
                    olhar = estados.esquerda;
                }
            }



            anime.SetInteger("olhar", (int)olhar);


        }
    }

	public void ReceiveDamage(float time){
		
		moving = false;

		Invoke ("StartMoving", time);
	}

	void StartMoving()
	{
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		moving = true;
	}

    void Die()
    {
        Destroy(this.gameObject, 0.1f);
    }
}
