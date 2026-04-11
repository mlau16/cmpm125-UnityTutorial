using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public CheckpointController next;
    public MeshRenderer left;
    public MeshRenderer right;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        VehicleController vehicle = other.gameObject.GetComponent<VehicleController>();
        if (vehicle != null)
        {
            next.left.materials[0].color = Color.red;
            next.right.materials[0].color = Color.red;
            left.materials[0].color = Color.white;
            right.materials[0].color = Color.white;
        }
        Debug.Log("trigger enter " + other.transform.name);
    }
}
