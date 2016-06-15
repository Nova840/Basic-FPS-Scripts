using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Networking;

public class CharacterHealth : NetworkBehaviour {

    private GameObject deadText;
    private GameObject target;

    private Transform spawnpointsContainer;
    private Transform[] spawnpoints;

    private Renderer[] renderers;
    private Collider[] colliders;
    private Rigidbody rb;

    public static CharacterHealth myHealth;

    [SyncVar(hook = "OnDeadChange")]//hide in inspector
    public bool dead = false;

    private void OnDeadChange(bool dead) {
        this.dead = dead;
        if (isLocalPlayer) {
            deadText.SetActive(dead);
            target.SetActive(!dead);
        }
        foreach (Collider c in colliders)
            c.enabled = !dead;
        foreach (Renderer r in renderers)
            r.enabled = !dead;
        rb.isKinematic = dead;
    }

    private void Awake() {
        Transform canvas = GameObject.Find("Canvas").transform;
        deadText = canvas.Find("Dead Text").gameObject;
        target = canvas.Find("Target").gameObject;
        //deadText.SetActive(false);
        spawnpointsContainer = GameObject.Find("SpawnPoints").transform;

        List<Transform> spawns = new List<Transform>();
        foreach (Transform t in spawnpointsContainer.GetComponentsInChildren<Transform>().ToList())
            if (t != spawnpointsContainer)
                spawns.Add(t);
        spawnpoints = spawns.ToArray<Transform>();

        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start() {
        if (isLocalPlayer)
            myHealth = this;
    }

    private void Update() {
        if (dead && Input.GetButtonDown("Respawn"))
            Respawn();
    }

    public void Respawn() {
        Transform spawnpoint = spawnpoints[Random.Range(0, spawnpoints.Length)];
        transform.position = spawnpoint.position;
        transform.rotation = spawnpoint.rotation;
        CmdSetDead(false);
    }

    [Command]
    public void CmdSetDead(bool dead) {
        this.dead = dead;
    }

}
