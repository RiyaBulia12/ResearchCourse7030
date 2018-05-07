using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GazeGestureManager : MonoBehaviour
{
    public static GazeGestureManager ggm_instance { get; private set; }
    public GameObject go { get; private set; }

    GestureRecognizer gr;
    void Start()
    {
        ggm_instance = this;
        gr = new GestureRecognizer();
        gr.Tapped += (args) =>
        {
            if (go != null)
            {
                go.SendMessageUpwards("OnSelect", SendMessageOptions.DontRequireReceiver);
            }
        };
        gr.StartCapturingGestures();
    }

    void Update()
    {
        GameObject oldFocusObject = go;
        var pos = Camera.main.transform.position;
        var for = Camera.main.transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(pos, for, out hit))
        {
            go = hit.collider.gameObject;
        }
        else
        {
            go = null;
        }
        if (go != oldFocusObject)
        {
            gr.CancelGestures();
            gr.StartCapturingGestures();
        }
    }
}