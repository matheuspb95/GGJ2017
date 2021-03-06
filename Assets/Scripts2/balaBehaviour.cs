﻿using UnityEngine;
using System.Collections;


public class balaBehaviour : MonoBehaviour {

	public Rigidbody2D bala;
	public GameObject personagem;

	private Vector3 alvo;
	private Vector3 personagemVec;
    public float velocity;
    public Sprite[] notas = new Sprite[4];
	// Use this for initialization
	void Awake () {
		personagem = GameObject.FindGameObjectWithTag("Player");
        int i = Random.Range(0, 4);
        GetComponent<SpriteRenderer>().sprite = notas[i];
	}

	void OnEnable(){
		alvo = Input.mousePosition;

		alvo = Camera.main.ScreenToWorldPoint (alvo);
		alvo = new Vector3 (alvo.x, alvo.y, -1);
		personagemVec = personagem.transform.position;
		alvo = alvo - personagemVec;
		bala.velocity = alvo.normalized* velocity;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (transform.position.x.ToString());
		if(transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 10 || transform.position.y < -10){
			gameObject.Recycle ();
		}
	}
}
