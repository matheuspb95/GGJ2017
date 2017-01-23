using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class botaoBehaviour : MonoBehaviour {

	public GameObject letrero;
	public GameObject creditos;

	private bool ativado;

	// Use this for initialization
	void Start () {
		ativado = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void jogar() {
        SceneManager.LoadScene("Main");
    }

	public void chamaCreditos(){
		if (ativado == true) {
			letrero.SetActive (false);
			creditos.SetActive (true);
			ativado = false;
		} else {
			ativado = true;
			letrero.SetActive (true);
			creditos.SetActive (false);
		}
	}
}
