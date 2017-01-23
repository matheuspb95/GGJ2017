using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{

    public LifeController vida;
    public GameObject botao;
    public AudioSource dano;

    [SerializeField]
    private int life;
    public int InitialLife;

	private bool vuneravel;

	private float tempo;
	public float tempoDeInvulnerabilidade;

    // Use this for initialization
    void Start()
    {
        life = InitialLife;
		tempo = 0;
		vuneravel = true;
    }

    // Update is called once per frame
    void Update()
    {
		tempo += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("EnemyBullet")){
			dano.Play();
            coll.Recycle();
            life--;
            if (life <= 0)
                Die();
        }
		/*
		else if (coll.CompareTag("Enemy")){
			//if(vuneravel){
			Debug.Log("entraaa");
				vuneravel = false;
				Invoke("tornaVulneravel",1);
	            life -= 2;
				tempo = 0;
				if (life <= 0) {
					Die ();
				}
			//}
        }
        */
        vida.ChangeValue(life);
    }

    public void Die()
    {
        personagemBehaviour.estaMorto = true;
        botao.SetActive(true);
        dano.Play();
        Debug.Log("Player die");
    }

    public void recomeca()
    {
        SceneManager.LoadScene("Main");
    }

	public void tornaVulneravel(){
		vuneravel = true;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag("Enemy")){
			if(vuneravel == true){
				vuneravel = false;
				dano.Play ();
				life -= 1;
				tempo = 0;
				Invoke("tornaVulneravel",tempoDeInvulnerabilidade);
				if (life <= 0) {
					Die ();
				}
				vida.ChangeValue(life);
			}
		}
	}

}
