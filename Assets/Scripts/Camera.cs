using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Camera : MonoBehaviour
{
    [SerializeField] private bool panoramic, firtsPerson, thirdPerson;

    // Start is called before the first frame update
    void Start()
    {
        panoramic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            panoramic = false;
            firtsPerson = true;
            thirdPerson = false;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            panoramic = false;
            firtsPerson = false;
            thirdPerson = true;
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            panoramic = true;
            firtsPerson = false;
            thirdPerson = false;
        }

        CamaraPanoramica();
        CamaraPrimeraPersona();
        CamaraTerceraPersona();
    }


    void CamaraPanoramica()
    {
        if (panoramic)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;

            x = -650.4f;
            y = 155.8f;
            z = 854.62f;

            float xRot = transform.rotation.x;
            float yRot = transform.rotation.y;
            float zRot = transform.rotation.z;

            xRot = 27.901f;
            yRot = -82.455f;
            zRot = 0f;

            Quaternion target = Quaternion.Euler(xRot, yRot, zRot);

            GameObject.Find("Camera").transform.rotation = Quaternion.Slerp(GameObject.Find("Camera").transform.rotation, target, 2f * Time.deltaTime);

            GameObject.Find("Camera").transform.position = Vector3.Slerp(GameObject.Find("Camera").transform.position, new Vector3(x, y, z), 2f * Time.deltaTime);
        }
    }

    void CamaraPrimeraPersona()
    {
        if (firtsPerson)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;

            float xRot = transform.rotation.x;
            float yRot = transform.rotation.y;
            float zRot = transform.rotation.z;

            x = -655.68f;
            y = 23.018f;
            z = 866.47f;

            xRot = -37.098f;
            yRot = -70.898f;
            zRot = 0f;

            Quaternion target = Quaternion.Euler(xRot, yRot, zRot);

            GameObject.Find("Camera").transform.rotation = Quaternion.Slerp(GameObject.Find("Camera").transform.rotation, target, 2f * Time.deltaTime);

            GameObject.Find("Camera").transform.position = Vector3.Slerp(GameObject.Find("Camera").transform.position, new Vector3(x, y, z), 2f * Time.deltaTime);
        }
    }

    void CamaraTerceraPersona()
    {
        if (thirdPerson)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            float xRot = transform.rotation.x;
            float yRot = transform.rotation.y;
            float zRot = transform.rotation.z;

            x = -646.04f;
            y = 28.79f;
            z = 859.45f;

            xRot = 29.788f;
            yRot = -62.72f;
            zRot = 0f;

            Quaternion target = Quaternion.Euler(xRot, yRot, zRot);

            GameObject.Find("Camera").transform.rotation = Quaternion.Slerp(GameObject.Find("Camera").transform.rotation, target, 2f * Time.deltaTime);

            GameObject.Find("Camera").transform.position = Vector3.Slerp(GameObject.Find("Camera").transform.position, new Vector3(x, y, z), 2f * Time.deltaTime);
        }
    }
}
