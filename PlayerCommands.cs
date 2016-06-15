using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerCommands : NetworkBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;

    [Command]
    public void CmdShoot(Vector3 position, Quaternion rotation, Vector3 velocity, float force, int id, float destroyAfter) {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, position, rotation);
        bullet.GetComponent<Shot>().playerId = id;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = velocity;
        rb.AddForce(bullet.transform.forward * force);
        NetworkServer.Spawn(bullet);
        Destroy(bullet, destroyAfter);
    }

    

}
