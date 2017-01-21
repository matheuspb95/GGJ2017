using UnityEngine;
using System.Collections;

public class lataBehaviour : MonoBehaviour {

	public Rigidbody2D lata;

	private Vector2 alvo;

	// Use this for initialization
	void Start () {
		alvo = new Vector2 (transform.position.x, transform.position.y + 5);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, alvo,0.03f);
	}
}
