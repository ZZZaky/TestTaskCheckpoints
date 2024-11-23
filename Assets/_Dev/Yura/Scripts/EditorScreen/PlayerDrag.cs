using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerDrag : MonoBehaviour
{
    [Inject] private SelectedObjectManager selectedObjectManager;
    public Outline outline;

    private Vector3 newPosition;
    private Quaternion newRotation;
    private float rotationAmount = 0.3f;
    private float movementTime = 5f;

    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        outline.enabled = false;
    }

    private void OnMouseDrag()
    {
        if (!this.enabled) { return; }
        selectedObjectManager.SelectPlayer(this.gameObject);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

        newPosition = new Vector3(objPosition.x, 0, objPosition.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
    }
}
