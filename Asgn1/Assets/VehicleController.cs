using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class VehicleController : MonoBehaviour
{

    public float impulse;
    public float turnrate;
    public CheckpointController target;
    public TextMeshProUGUI timelbl;

    float desired_acceleration;
    float side_acceleration;
    float starttime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        starttime = Time.time;
        target.left.materials[0].color = Color.red;
        target.right.materials[0].color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddRelativeForce(-desired_acceleration * impulse, 0, side_acceleration * impulse);

        float dx = (Mouse.current.position.x.value - Screen.width / 2) / turnrate;
        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.Rotate(0, dx, 0);
        }

        timelbl.text = string.Format("Current time: {0:F2} seconds", (Time.time - starttime));
    }

    void OnMove(InputValue action)
    {
        var movement = action.Get<Vector2>();
        desired_acceleration = movement.y;
        side_acceleration = movement.x;
    }
}
