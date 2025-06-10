using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField]
    private Transform interactCheckBox;

    [SerializeField]
    private Vector2 interactCheckBoxDimensions;

    [SerializeField]
    private LayerMask interactLayerMask;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteractObject();   
        }
    }

    private void CheckInteractObject()
    {
        Collider2D checkBox = Physics2D.OverlapBox(interactCheckBox.position, interactCheckBoxDimensions, 1, interactLayerMask);

        if (!checkBox) 
        {
            return;
        }

        InteractObject io = checkBox.gameObject.GetComponent<InteractObject>();
        if (io == null)
            return;

        io.Interact();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(interactCheckBox.position, interactCheckBoxDimensions / 2);
    }
}
