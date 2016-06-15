using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CharacterMove : NetworkBehaviour {

    [SerializeField]
    private float speed = 1, rotateSpeed = 1;

    private Rigidbody rb;

    private void Start() {
        if (!isLocalPlayer) {
            transform.Find("Look Container").GetComponent<LookX>().enabled = false;
            Destroy(transform.Find("Look Container/Camera").gameObject);
        }
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if (!isLocalPlayer)
            return;

        Vector3 move = transform.forward * speed * Input.GetAxis("Vertical");
        move += transform.right * speed * Input.GetAxis("Horizontal");
        move = Vector3.ClampMagnitude(move, speed);
        rb.velocity += move;
        rb.angularVelocity = Vector3.zero;

        transform.Rotate(transform.up, rotateSpeed * Input.GetAxis("Arrow Horizontal"));
    }

}
