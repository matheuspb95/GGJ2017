using UnityEngine;
using System.Collections;

public class SpawnObj : MonoBehaviour {
    public GameObject Prefab;
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
            GameObject newObj = Prefab.Spawn(transform.position);
        }
    }
}
