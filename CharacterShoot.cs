using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CharacterShoot : MonoBehaviour {

    [SerializeField]
    private float cooldownTime = 1, shootForce = 100, bulletTime = 5;

    [SerializeField]
    private NetworkIdentity networkIdentity;

    private float timeLastShot;

    private void Awake() {
        timeLastShot = Time.time;
    }

    private void Update() {
        if (!networkIdentity.isLocalPlayer)
            return;

        if (Input.GetButton("Fire1") && TimeSinceLastShot() > cooldownTime) {
            networkIdentity.GetComponent<PlayerCommands>().CmdShoot(transform.position, transform.rotation, transform.root.GetComponent<Rigidbody>().velocity, shootForce, (int)networkIdentity.netId.Value, bulletTime);
            timeLastShot = Time.time;
        }
    }

    private float TimeSinceLastShot() {
        return Time.time - timeLastShot;
    }


}
