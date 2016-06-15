using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

    [SerializeField]
    private float time = 5;

    private void Awake() {
        Destroy(gameObject, time);
    }
}
