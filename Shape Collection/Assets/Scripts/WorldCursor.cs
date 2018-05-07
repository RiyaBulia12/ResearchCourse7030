using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCursor : MonoBehaviour
{
    private MeshRenderer mr;

    void Start()
    {
        mr = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    void Update(){
        var pos = Camera.main.transform.position;
        var fwd = Camera.main.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(pos, fwd, out hit))
        {
            mr.enabled = true;

            this.transform.position = hit.point;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
        else
        {
            mr.enabled = false;
        }
    }
}
