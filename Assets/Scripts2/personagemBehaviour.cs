using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class personagemBehaviour : MonoBehaviour {

    public Animator anime;
    public float velocidade;

	static public bool estaMorto;

	public GameObject bala;

	public bool praDireita;
	public bool praEsquerda;
	public bool praCima;
	public bool praBaixo;

    public int estado;

	public float tempTiro;
	private float contTempTiro;
	public bool estaAtirando;

	public float tempCamp;
	private float contTempCamp;
	public bool estaComCampo;

	public TextMesh pontos;
	public TextMesh mensagem;
	private bool caiu;

	static public int kills = 0;

	private List<GameObject> inimigos = new List<GameObject>();

    enum estados { baixo, cima, esquerda, direita }

    // Use this for initialization
    void Start () {
        //velocidade = 4;
		caiu = false;
		contTempTiro = 0;
		estaAtirando = false;
		estaMorto = false;
        anime = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.rotation = new Quaternion(0,0,0,0);

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if(estaMorto == false){
            inimigos.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
            int numenemies = 0;
            foreach (GameObject inimigo in inimigos)
            {
                float distance = Vector2.Distance(inimigo.transform.position, transform.position);
                if (distance < 0.2f)
                {
                    numenemies++;
                }
            }
            inimigos.Clear();
            float vel = velocidade * (1 / (numenemies + 1));
            Vector2 movimente = new Vector2 (moveHorizontal, moveVertical);
			transform.Translate(movimente*velocidade*Time.deltaTime);

			if(Input.GetButtonDown("Fire1")){
				if(estaAtirando == false){
					bala.Spawn(new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
					estaAtirando = true;
				}
			}

			if(estaAtirando == true){
				contTempTiro += Time.deltaTime;
				if(contTempTiro >= tempTiro){
					estaAtirando = false;
					contTempTiro = 0;
				}
			}

			if(Input.GetButtonDown("Fire2")){
				if(estaComCampo == false){
					inimigos.AddRange(GameObject.FindGameObjectsWithTag ("Enemy"));

					foreach (GameObject inimigo in inimigos) {
						float distance = Vector2.Distance (inimigo.transform.position, transform.position);
						if (distance < 1) {
							Vector2 direction = inimigo.transform.position - transform.position;
							inimigo.GetComponent<segurancaBehaviour> ().ReceiveDamage (2f);

							inimigo.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
							inimigo.GetComponent<Rigidbody2D> ().AddForce (direction.normalized * 200);
						}
					}
					inimigos.Clear();
					estaComCampo = true;
				}
			}

			if(estaComCampo == true){
				contTempCamp += Time.deltaTime;
				if(contTempCamp >= tempCamp){
					estaComCampo = false;
					contTempCamp = 0;
				}
			}
		}

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

		pontos.text = "Pontos: " + kills.ToString ();

		if(estaMorto == true){
			mensagem.text = "Voce moreu!";
			if (caiu == false) {
				anime.SetBool ("morto", true);
				caiu = true;
			} else {
				anime.SetBool ("morto", false);
			}
		}

		anime.SetInteger("estado", estado);
		anime.SetBool("cima", praCima);
		anime.SetBool("baixo", praBaixo);
		anime.SetBool("esquerda", praEsquerda);
		anime.SetBool("direita", praDireita);
    }	
}
