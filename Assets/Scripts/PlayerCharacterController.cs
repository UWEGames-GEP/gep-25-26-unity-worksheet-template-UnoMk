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
            GetComponent<Inventory>().RemoveItem();
        }
    }
}