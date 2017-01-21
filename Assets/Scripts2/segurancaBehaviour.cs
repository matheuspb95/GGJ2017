using UnityEngine;
using System.Collections;

public class segurancaBehaviour : MonoBehaviour
{

    public Transform personagem;
    private Vector2 alvo;

    // Use this for initialization
    void Start()
    {
        personagem = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        alvo = personagem.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, alvo, 0.04f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject, 0.1f);
    }
}
