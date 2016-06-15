using UnityEngine;
using System.Collections;

public class LockAxis : MonoBehaviour {

    [SerializeField]
    private bool lockX = true, lockY = false, lockZ = true;

	private void Update () {
        transform.localEulerAngles = new Vector3(
            lockX ? 0 : transform.localEulerAngles.x,
            lockY ? 0 : transform.localEulerAngles.y,
            lockZ ? 0 : transform.localEulerAngles.z
            );
	}
}
