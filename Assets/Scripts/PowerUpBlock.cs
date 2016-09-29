using UnityEngine;
using System.Collections;

public class PowerUpBlock : MonoBehaviour
{

    public BoxCollider2D boxcollider;
    public GameObject spawnPoint;
    public GameObject spawnedPrefab;

    public bool spawned = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D col) {

        if (col.tag == "Player" && spawned == false)
        {
            if (spawnedPrefab)
            {
                Instantiate(spawnedPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            }
            //Debug.Log("memed");
            spawned = true;
        }
    }
}
