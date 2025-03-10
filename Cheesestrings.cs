using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheesestrings : MonoBehaviour
{
    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.AddScore(1);
        Destroy(gameObject);
    }
}
