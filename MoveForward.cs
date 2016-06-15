using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

    [SerializeField]
    private float speed = 1;

    private void FixedUpdate () {
        Vector3 move = transform.forward * speed;
        transform.position += move;
	}

}
