using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CheckpointDrag : MonoBehaviour
{
    [Inject] private BezierFactory bezierFactory;

    public void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        transform.position = new Vector3(objPosition.x, 0, objPosition.z);
        bezierFactory.UpdatePoint(this.GetComponent<Checkpoint>().checkpointNumber, transform.position);
    }
}
