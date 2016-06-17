using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float turn;
    public float ascDesc;
    public float startDrag;
    public float endDrag;
    private List<Color> colors = new List<Color>();
    private Rigidbody rb;
    private AudioSource engineSound;
    private int colorPicker;
    private bool brightColors;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        engineSound = GetComponent<AudioSource>();
        rb.maxDepenetrationVelocity = 0.1f;
        
        colors.Add(Color.green);
        colors.Add(Color.red);
        colors.Add(new Color(0, 1, 1, 1));
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float turnShip = Input.GetAxis("Turning");
        float heightAdjustment = Input.GetAxis("Height");

        Vector3 movement = new Vector3(moveHorizontal, -ascDesc * heightAdjustment, -moveVertical);

        if (turnShip == 0.0f)
            rb.angularDrag = endDrag;
        else
            rb.angularDrag = startDrag;

        rb.AddRelativeForce(movement * speed);
        rb.AddRelativeTorque(Vector3.up * turnShip * turn);

        if (Input.GetButtonDown("Y"))
        {
            brightColors = !brightColors;
            print(brightColors);
        }

        if (Input.GetButtonDown("B"))
        {
            colorPicker++;
            colorPicker %= colors.Count;
            print(colorPicker);
        }

        if (Input.GetButtonDown("A"))
        {
            Transform cam = Camera.main.transform;
            Ray ray = new Ray(cam.position, cam.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (brightColors)
                {
                    foreach (Material mat in hit.collider.gameObject.GetComponent<Renderer>().materials)
                        mat.color = colors[colorPicker];
                }
                else
                {
                    hit.collider.gameObject.SendMessage("CorrectColors");
                    print(hit.collider.gameObject);
                }
            }
        }

        engineSound.volume = 0.4f + 0.1f * rb.velocity.magnitude;

    }

    void OnCollisionEnter(Collision collision)
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
    
    void OnCollisionExit(Collision collision)
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
}