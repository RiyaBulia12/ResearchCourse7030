using UnityEngine;

public class SphereCommands : MonoBehaviour
{
    Vector3 vec;

    void Start()
    {
        vec = this.transform.localPosition;
    }

    void OnSelect()
    {
        if (!this.GetComponent<Rigidbody>())
        {
            var obj = this.gameObject.AddComponent<Rigidbody>();
            obj.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }

    void OnReset()
    {
        var obj = this.GetComponent<Rigidbody>();
        if (obj != null)
        {
            obj.isKinematic = true;
            Destroy(obj);
        }

        this.transform.localPosition = vec;
    }

    void OnDrop()
    {
        OnSelect();
    }
}