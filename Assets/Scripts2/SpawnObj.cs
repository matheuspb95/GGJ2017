using UnityEngine;
using System.Collections;

public class SpawnObj : MonoBehaviour {
    public GameObject Prefab1, Prefab2;
    public float FireRate;
    public bool CanSpawn;
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
            yield return new WaitForSeconds(FireRate);
            if(Random.value < 0.5f)
            {
                GameObject newObj = Prefab1.Spawn(transform.position);
            }
            else
            {
                GameObject newObj = Prefab2.Spawn(transform.position);
            }
        }
    }
}
