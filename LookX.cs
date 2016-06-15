using UnityEngine;
using System.Collections;

public class LookX : MonoBehaviour {

    [SerializeField]
    private float speed = 1, lowerLimit = 90, upperLimit = 270;

    private void FixedUpdate() {
        transform.Rotate(Vector3.left * speed * Input.GetAxis("Arrow Vertical"));
        Limit();
    }

    private void Limit() {
        float angle = transform.localEulerAngles.x;

        if (angle > 180 && angle < upperLimit)
            angle = upperLimit;
        else if (angle <= 180 && angle > lowerLimit)
            angle = lowerLimit;

        transform.localEulerAngles = new Vector3(angle, 0, 0);
    }

}
