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
    int lapCount = 0;

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

        float racetime = Time.time - starttime;
        timelbl.text = "Lap: " + lapCount + "  Time: " + racetime.ToString("F2");
    
    }

    void OnMove(InputValue action)
    {
        var movement = action.Get<Vector2>();
        desired_acceleration = movement.y;
        side_acceleration = movement.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckpointController checkpoint = other.GetComponent<CheckpointController>();

        if (checkpoint != null && checkpoint == target)
        {
            if (checkpoint.lapStart)
            {
                lapCount++;
                starttime = Time.time;
            }

            target = target.next;
        }
    }

}
