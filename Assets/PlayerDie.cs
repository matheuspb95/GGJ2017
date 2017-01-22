using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour {

	public LifeController vida;
	public GameObject botao;

	[SerializeField]
	private int life;
	public int InitialLife;

	// Use this for initialization
	void Start () {
		life = InitialLife;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.CompareTag ("EnemyBullet")) {
			coll.Recycle ();
			life--;
			if (life <= 0)
				Die ();
		}
		else if (coll.CompareTag ("Enemy")) {
			//coll.Recycle ();
			life -= 2;
			if (life <= 0)
				Die ();
		}
        vida.ChangeValue(life);
	}

	public void Die(){
		personagemBehaviour.estaMorto = true;
		botao.SetActive (true);
		Debug.Log ("Player die");
	}

	public void recomeca(){
		SceneManager.LoadScene("Main");
	}
		
}
