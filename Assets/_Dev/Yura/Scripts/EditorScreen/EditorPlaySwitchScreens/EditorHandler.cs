using UnityEngine;

public class EditorHandler : MonoBehaviour
{
    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    public void Activate()
    {
        this.gameObject.SetActive(true);
    }
}
