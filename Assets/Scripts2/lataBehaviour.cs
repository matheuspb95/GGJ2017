using UnityEngine;
using System.Collections;

public class lataBehaviour : MonoBehaviour {

	public Rigidbody2D lata;
    public Transform player;
    public float velocity;
    private Vector2 alvo;
    public float distance;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Vector2 direction = player.position - transform.position;
        alvo = player.position + (Vector3)direction.normalized;

        
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector2.Distance(transform.position, alvo);

        if (distance < 0.5f)
            transform.position = Vector3.MoveTowards(transform.position, alvo, velocity * Time.deltaTime * distance * 2); 
        else
            transform.position = Vector3.MoveTowards(transform.position, alvo, velocity * Time.deltaTime);
		if (distance < 0.1f) {
			Animator anim = GetComponent<Animator> ();
			if (anim != null) {
				anim.Stop ();
			}
			Invoke ("RecycleNow", 0.5f);
		}
    }

	void RecycleNow(){
		gameObject.Recycle();		
	}
}
