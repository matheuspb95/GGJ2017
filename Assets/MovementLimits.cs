using UnityEngine;
using System.Collections;

public class MovementLimits : MonoBehaviour {
    public Vector2 MaxLimit, MinLimit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < MinLimit.x)
            transform.position = new Vector3(MinLimit.x, transform.position.y, transform.position.z);
        if (transform.position.x > MaxLimit.x)
            transform.position = new Vector3(MaxLimit.x, transform.position.y, transform.position.z);

        if (transform.position.y < MinLimit.y)
            transform.position = new Vector3(transform.position.x, MinLimit.y, transform.position.z);
        if (transform.position.y > MaxLimit.y)
            transform.position = new Vector3(transform.position.x, MaxLimit.y, transform.position.z);

    }
}
