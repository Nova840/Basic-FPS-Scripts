using UnityEngine;
using System.Collections;

public class ExitGameOnEscape : MonoBehaviour {

	private void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
	}

}
