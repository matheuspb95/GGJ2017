using UnityEngine;
using System.Collections;

public class EnemyDie : MonoBehaviour {
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
		if (coll.CompareTag ("PlayerBullet")) {
			coll.Recycle ();
			GetComponent<segurancaBehaviour> ().ReceiveDamage (0.2f);
			life -= 2;
			if (life <= 0)
				Die ();
		}
	}

	public void Die(){
		gameObject.Recycle ();
		Debug.Log ("Enemy die");
		personagemBehaviour.kills++;
	}
}
