using UnityEngine;
using System.Collections;

public class PowerUpBlock : MonoBehaviour{

    //Variables

    AudioManager audioManager;

    public AudioClip spawnPrefabSound;

    public Material spawnedMaterial;
    MeshRenderer meshRenderer;
    public BoxCollider2D boxcollider;
    public GameObject spawnPoint;
    public GameObject spawnedPrefab;

    public bool spawned = false;

    // Use this for initialization
    void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    //spawn selected prefab when colliding with trigger under block
    void OnTriggerEnter2D(Collider2D col) {

        if (col.tag == "Player" && spawned == false){

            if (spawnedPrefab) {

                audioManager.PlayAudio(spawnPrefabSound);
                Instantiate(spawnedPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                meshRenderer.material = spawnedMaterial;
            }
            //Debug.Log("memed");
            spawned = true;
        }
    }
}
