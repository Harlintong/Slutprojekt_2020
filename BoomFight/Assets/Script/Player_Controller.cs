using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Player_Controller : NetworkBehaviour
{
    [SerializeField]
    float MovementSpeed = 3f;

    [SerializeField]
    float RotationSpeed = 150f;

    [SerializeField]
    GameObject Bomb;

    [SerializeField]
    GameObject BombSpawnPoint;

    float TimeBetweenBomb = 1f;
    float TimeSinceLastBomb = 0f;

    public override void OnStartLocalPlayer()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        float yRotation = Input.GetAxisRaw("Horizontal") * RotationSpeed * Time.deltaTime;
        float zMovement = Input.GetAxisRaw("Vertical") * MovementSpeed * Time.deltaTime;

        Vector3 RotationVector = new Vector3(0, yRotation, 0);
        Vector3 MovementVector = new Vector3(0, 0, zMovement);

        transform.Rotate(RotationVector);
        transform.Translate(MovementVector);

        TimeSinceLastBomb += Time.deltaTime;
    }
}
