using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform Lava;
    public float lavaSpeed = 2.0f;
    Vector3 startPos;

    private void Start()
    {
        startPos = this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.transform.position = respawnPoint.transform.position;
            this.transform.position = startPos;
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * lavaSpeed);
    }

}
