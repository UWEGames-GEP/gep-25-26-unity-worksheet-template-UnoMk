using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : ThirdPersonController
{
    public GameManager gameManager;
    private void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            gameManager.Pausing();
        }
    }

    private void OnRemoveItem(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Remove Item");
            GetComponent<Inventory>().RemoveItem();
        }
    }
}