using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public Transform controller;

    private bool isDown = false;

    // Update is called once per frame
    private void Update() {

        // If the trigger has been pulled for the first time in the button press cycle
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.Active) && !isDown) {
            isDown = true;

            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit[] hits = Physics.RaycastAll(ray);

            if (hits.Length > 0) {
                controller.position = hits[0].point + new Vector3(0, 1.6f, 0);
                Debug.Log("Boom!");
            }
        }

        // Reset the down
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.Active)) {
            isDown = false;
        }
    }
}
