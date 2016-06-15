using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterHealth))]
public class DieIfBelow : MonoBehaviour {

    [SerializeField]
    private float threshold = -100;

    private void Update() {
        if (transform.position.y < threshold && !CharacterHealth.myHealth.dead)
            CharacterHealth.myHealth.CmdSetDead(true);
    }

}
