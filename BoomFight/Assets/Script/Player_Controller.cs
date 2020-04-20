using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Player_Controller : NetworkBehaviour
{
    [SerializeField]
    Camera playerCamera;

    [SerializeField]
    float MovementSpeed = 6f;

    [SerializeField]
    GameObject Bomb;

    [SerializeField]
    GameObject BombSpawnPoint;

    Vector3 movement;
    Rigidbody playerRigidbody;

    int floorMask;

    float CameraVerticalAngle = 0f;
    float TimeBetweenBomb = 5f;
    float TimeSinceLastBomb = 0f;
    float camRayLength = 100f;

    public override void OnStartLocalPlayer()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    void Awake()
    {
        floorMask = LayerMask.GetMask("Ground");

        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        float yRotation = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");

        Move(yRotation, zMovement);

        Turning();

        TimeSinceLastBomb += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (TimeSinceLastBomb > TimeBetweenBomb)
            {
                //Fire();
                TimeSinceLastBomb = 0;
            }
        }
    }

    void Move (float yMovement, float zMovement)
    {
        movement.Set(yMovement, 0f, zMovement);

        movement = movement.normalized * MovementSpeed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            playerRigidbody.MoveRotation(newRotation);
        }
    }

    /*void Fire()
    {
        GameObject Bomb = Instantiate(Bomb, BombSpawnPoint.position, BombSpawnPoint.rotation);
    }*/
}
