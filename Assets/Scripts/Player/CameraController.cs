using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;

    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 10;

    private float currentZoom = 6f;

    public float pitch = 2f;

    public float yawSpeed = 100f;

    private float currentYaw = 70f;

    void Update()
    {
        if (!PauseMenu.GameIsPaused && !InventoryUI.invetoryIsOpened)
        {
            currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        }

        if (Input.GetMouseButton(2))
        {
            currentYaw += Input.GetAxis("Mouse X") * yawSpeed * Time.deltaTime;
        }
    }


    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
