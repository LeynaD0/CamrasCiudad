using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float speedRotation;
    [SerializeField] private CharacterController player;
    [SerializeField] private Transform transformCharacter;
    [SerializeField] private GameObject cameraCharacter;
    [SerializeField] private bool primera_tercera;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float fallVelocity, gravity;

    float turnSmoothVelocity;

    //[SerializeField] private Transform cam;

    private Vector3 move;
    private float rotationX;

    private void Start()
    {
        cameraCharacter = GameObject.Find("Camera");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            primera_tercera = !primera_tercera;
        }

        SetGravity();
        Sprint();
        //MovimientoDeCamaraTerceraPersona();
        MovimientoDeCamaraPrimeraPersona();
        terceraPersona();
    }

    /*void MovimientoDeCamaraTerceraPersona()
    {
        if (!primera_tercera)
        {

            float movX = Input.GetAxis("Horizontal");
            float movZ = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(movX, move.y, movZ).normalized;

            if(direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                player.Move(moveDir.normalized * speedMove * Time.deltaTime);
            }
        }
       
    }*/

    void MovimientoDeCamaraPrimeraPersona()
    {
        if (primera_tercera)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;

            float xRot = transform.rotation.x;
            float yRot = transform.rotation.y;
            float zRot = transform.rotation.z;

            x = 0f;
            y = 0.626f;
            z = 0.233f;

            xRot = 0f;
            yRot = 0f;
            zRot = 0f;

            Quaternion target = Quaternion.Euler(xRot, yRot, zRot);

            GameObject.Find("Camera").transform.localRotation = Quaternion.Slerp(GameObject.Find("Camera").transform.localRotation, target, 2f * Time.deltaTime);

            GameObject.Find("Camera").transform.localPosition = Vector3.Slerp(GameObject.Find("Camera").transform.localPosition, new Vector3(x, y, z), 2f * Time.deltaTime);
            float movX = Input.GetAxis("Horizontal");
            float movZ = Input.GetAxis("Vertical");

            move = transform.right * movX + transform.forward * movZ;
            player.SimpleMove(move * speedMove);

            float mouseX = Input.GetAxis("Mouse X") * speedRotation;
            float mouseY = Input.GetAxis("Mouse Y") * speedRotation;

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            cameraCharacter.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transformCharacter.Rotate(Vector3.up * mouseX);

        }
        
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedMove = 8f;
        }

        else
        {
            speedMove = 4f;
        }
    }

    void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
        }

        move.y = fallVelocity;
    }

    void terceraPersona()
    {
        if (!primera_tercera)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;

            float xRot = transform.rotation.x;
            float yRot = transform.rotation.y;
            float zRot = transform.rotation.z;

            x = 0f;
            y = 1.700001f;
            z = -3.859985f;

            xRot = 16.13f;
            yRot = 0f;
            zRot = 0f;

            Quaternion target = Quaternion.Euler(xRot, yRot, zRot);

            GameObject.Find("Camera").transform.localRotation = Quaternion.Slerp(GameObject.Find("Camera").transform.localRotation, target, 2f * Time.deltaTime);

            GameObject.Find("Camera").transform.localPosition = Vector3.Slerp(GameObject.Find("Camera").transform.localPosition, new Vector3(x, y, z), 2f * Time.deltaTime);

            float movX = Input.GetAxis("Horizontal");
            float movZ = Input.GetAxis("Vertical");

            move = transform.right * movX + transform.forward * movZ;
            player.SimpleMove(move * speedMove);
        }
    }
}
