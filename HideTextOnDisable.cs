using UnityEngine;
using System.Collections;

public class HideTextOnDisable : MonoBehaviour {

    private void OnDestroy() {
        GameObject canvas = GameObject.Find("Canvas");
        if (!canvas)//In case te game is closing.
            return;
        GameObject text = canvas.transform.Find("Dead Text").gameObject;
        if (!text)
            return;

        text.SetActive(false);
    }

}
