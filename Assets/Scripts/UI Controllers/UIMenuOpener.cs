using UnityEngine;
using UnityEngine.InputSystem;

public class UIMenuOpener : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject inventoryUI;

    public void MenuOpen(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Activate the menu UI GameObject
            if (menuUI != null)
            {
                menuUI.SetActive(true);
                Debug.Log("Menu UI Activated: Button Held");
            }
            else
            {
                Debug.LogError("menuUI GameObject is not assigned in the Inspector!");
            }
        }
        // Check if the action has just been canceled (button released)
        else if (context.canceled)
        {
            // Deactivate the menu UI GameObject
            if (menuUI != null)
            {
                menuUI.SetActive(false);
                Debug.Log("Menu UI Deactivated: Button Released");
            }
        }
    }   
    
    public void InventoryOpen(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Activate the menu UI GameObject
            if (inventoryUI != null)
            {
                inventoryUI.SetActive(true);
                
            }
            else
            {
                Debug.LogError("inventoryUI GameObject is not assigned in the Inspector!");
            }
        }
        // Check if the action has just been canceled (button released)
        else if (context.canceled)
        {
            // Deactivate the menu UI GameObject
            if (inventoryUI != null)
            {
                inventoryUI.SetActive(false);
            }
        }
    }

}
