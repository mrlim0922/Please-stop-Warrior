using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGauge : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Translate(0.001f, 0, 0);
	}
}
