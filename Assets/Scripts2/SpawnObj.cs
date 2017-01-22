using UnityEngine;
using System.Collections;

public class SpawnObj : MonoBehaviour {
    public GameObject Prefab1, Prefab2;
    public float Time, TimeVar;
    public int Min, Max;
    public bool CanSpawn;
    public Vector2 MaxLimit, MinLimit;
    // Use this for initialization
    void Start () {
        StartCoroutine(Spawn());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Spawn()
    {
        while (CanSpawn)
        {
            yield return new WaitForSeconds(Time + Random.Range(-TimeVar, TimeVar));
            int value = Random.Range(Min, Max+1);
            if(Random.value < 0.5f)
            {
                for (int i = 0; i < value; i++)
                {
                    GameObject newObj = Prefab1.Spawn(transform.position);
                    ChangePosition();
                }
            }
            else
            {
                for (int i = 0; i < value; i++)
                {
                    GameObject newObj = Prefab2.Spawn(transform.position);
                    ChangePosition();
                }
            }
        }
    }


    void ChangePosition()
    {

        float posx = Random.Range(MaxLimit.x, MinLimit.x);
        float posy = Random.Range(MaxLimit.y, MinLimit.y);

        transform.position = new Vector3(posx, posy);
    }
}
