using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

    void OnTriggerExit(Collider col)
    {
        GameObject objectLeft = col.gameObject;

        if (objectLeft.GetComponent<Pin>()){
            Destroy(objectLeft);
        }
    }
}
