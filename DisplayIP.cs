using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net;

[RequireComponent(typeof(Text))]
public class DisplayIP : MonoBehaviour {

    private Text text;

    private void Awake() {
        text = GetComponent<Text>();
    }

    private void OnEnable() {
        text.text = Network.player.ipAddress;
    }

}
