using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Transform SpawnPosition;
    public void SpawnPlayer(Vector3 position)
    {
        transform.position = position;
        Physics.SyncTransforms();
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Water") )
        {
            transform.GetComponent<PlayerHealth>().TakeDamage();
            this.SpawnPlayer(SpawnPosition.position);
        }
    }
}
