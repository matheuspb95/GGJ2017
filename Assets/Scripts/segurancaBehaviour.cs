using UnityEngine;
using System.Collections;

public class segurancaBehaviour : MonoBehaviour {

	public Transform personagem;
	private Vector2 alvo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		alvo = personagem.transform.position;
		transform.position = Vector3.MoveTowards(transform.position, alvo,0.04f);
	}
}
