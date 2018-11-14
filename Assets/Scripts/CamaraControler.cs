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
            var other = GameObject.Find("Reference").transform.position; // just for my test
            var facing = transform.up; // what direction your object is "facing" is not always clear cut
            var self = transform.position;

            Debug.DrawLine(self, self + facing * 100f, Color.green); //here we scale the facing vector by some amount to make it better visible
            Debug.DrawLine(self, other, Color.red);


            // the vector from A to B is equal to B-A
            // when calculating angles, we don't care about the magnitude of the vectors, just the direction

            var angleBetween = Vector3.Angle(facing, other - self);
       // Debug.Log(angleBetween);
       // Debug.Log(MaxCamaraRotationDown + 31f);
        //Debug.Log(MaxCamaraRotationUp + 91f);
        if (angleBetween < 160f && angleBetween > 70f)
        {
            float pitch = Input.GetAxisRaw("Mouse Y") * -1f * sensitivity * Time.deltaTime;
            transform.Rotate(pitch * Vector3.right, Space.Self);
        }
        if (angleBetween < 170f && angleBetween >= 160f)
        {
            float pitch1 = Input.GetAxisRaw("Mouse Y") * -1f * sensitivity * Time.deltaTime;
           // Debug.Log(pitch1);
            if (pitch1 > 0)
            {
                //Debug.Log("Correction not working");
                transform.Rotate(pitch1 * Vector3.right, Space.Self);
            }
        }
        if (angleBetween > 61f && angleBetween <= 70f)
        {
            float pitch2 = Input.GetAxisRaw("Mouse Y") * -1f * sensitivity * Time.deltaTime;
            if (pitch2 < 0)
            {
                //Debug.Log("correction not working");
                transform.Rotate(pitch2 * Vector3.right, Space.Self);
            }
        }
        if (angleBetween < MaxCamaraRotationDown+30f)
        {
            //Debug.Log("ActiveMenorque60");
            transform.localRotation = Quaternion.Euler(60, 0, 0);
            
        }
        if (angleBetween > MaxCamaraRotationUp+110f)
        {
            //Debug.Log("Activemayorque150");
             transform.localRotation = Quaternion.Euler(-28, 0, 0);

        }


    }
}