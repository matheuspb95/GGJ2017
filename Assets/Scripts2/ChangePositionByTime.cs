using UnityEngine;
using System.Collections;

public class ChangePositionByTime : MonoBehaviour {
    public float time;
    public bool CanChange;
    public Vector2 MaxLimit, MinLimit;
    // Use this for initialization
    void Start () {
        StartCoroutine(ChangePosition());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator ChangePosition()
    {
        while (CanChange)
        {
            yield return new WaitForSeconds(time);
            float posx = Random.Range(MaxLimit.x, MinLimit.x);
            float posy = Random.Range(MaxLimit.y, MinLimit.y);

            transform.position = new Vector3(posx, posy);
        }

    }
}
