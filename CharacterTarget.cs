using UnityEngine;
using System.Collections;

public class CharacterTarget : MonoBehaviour {

    private GameObject target;

    private void Awake() {
        target = GameObject.Find("Canvas").transform.Find("Target").gameObject;
    }

    private void Start() {
        target.SetActive(true);
    }

    private void OnDestroy() {
        if (target)
            target.SetActive(false);
    }

}
