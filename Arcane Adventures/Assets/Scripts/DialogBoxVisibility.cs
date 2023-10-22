using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    public GameObject targetObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (targetObject != null)
            {
                targetObject.SetActive(!targetObject.activeSelf);
            }
        }
    }
}