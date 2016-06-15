using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Shot : NetworkBehaviour {

    [HideInInspector, SyncVar]
    public int playerId;

    private void OnTriggerEnter(Collider other) {
        GameObject root = other.transform.root.gameObject;
        if (!root.CompareTag("Player"))
            return;

        NetworkIdentity networkIdentity = root.GetComponent<NetworkIdentity>();

        if (networkIdentity.isLocalPlayer && networkIdentity.netId.Value != playerId)//if you're hit by a bullet that's not yours.
            CharacterHealth.myHealth.CmdSetDead(true);
    }

}
