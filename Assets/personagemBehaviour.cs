﻿using UnityEngine;
using System.Collections;

public class personagemBehaviour : MonoBehaviour {

	public float velocidade;

	public bool praDireita;
	public bool praEsquerda;
	public bool praCima;
	public bool praBaixo;


	// Use this for initialization
	void Start () {
		//velocidade = 4;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.rotation = new Quaternion(0,0,0,0);

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movimente = new Vector2 (moveHorizontal, moveVertical);
		transform.Translate(movimente*velocidade*Time.deltaTime);
	}
}
