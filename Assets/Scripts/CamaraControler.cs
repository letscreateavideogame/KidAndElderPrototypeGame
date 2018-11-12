using UnityEngine;
using System.Collections;

public class CamaraControler : MonoBehaviour
{

    public float sensitivity = 200f;
    public float MaxCamaraRotationDown = 30f;
    public float MaxCamaraRotationUp = 60f;
   // float MaxCamaraRotationDonwCorrected = 60f;
   // float MaxCamaraRotationUpCorrected = MaxCamaraRotationUpCorrected + MaxCamaraRotationUp + 90f;
    // Update is called once per frame
    void Update()
    {
            var other = GameObject.Find("Cube").transform.position; // just for my test
            var facing = transform.up; // what direction your object is "facing" is not always clear cut
            var self = transform.position;

            Debug.DrawLine(self, self + facing * 100f, Color.green); //here we scale the facing vector by some amount to make it better visible
            Debug.DrawLine(self, other, Color.red);

            // the vector from A to B is equal to B-A
            // when calculating angles, we don't care about the magnitude of the vectors, just the direction

            var angleBetween = Vector3.Angle(facing, other - self);
        if (angleBetween <= 150f && angleBetween >= 60f)
        {

            float pitch = Input.GetAxisRaw("Mouse Y") * -1f * sensitivity * Time.deltaTime;
            transform.Rotate(pitch * Vector3.right, Space.Self);

        }
        if (angleBetween >= MaxCamaraRotationDown+30f)
        {
            float pitch = 60f * Time.deltaTime;
            transform.Rotate(pitch * Vector3.right, Space.Self);
        }
        if (angleBetween <= MaxCamaraRotationUp+90f)
        {
            float pitch = -60f * Time.deltaTime;
            transform.Rotate(pitch * Vector3.right, Space.Self);
        }


    }
}