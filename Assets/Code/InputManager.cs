using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance; 
    
    //An accessor to return our instance
    public static InputManager Instance 
    {
        get { return instance; }
    }
    private PlayerControls playerControls;


    private void Awake()
    {
        //Singleton
        //This means there are two InputManagers in the scene. Very bad. No likey. So we get rid of it
        if (instance != null && instance != this) { Destroy(this.gameObject); } 
        else { instance = this; } //Assign the instance to this script
        
        
        playerControls = new PlayerControls();

    }

    //Helper functions so other scripts can call these functions and not instantiate the player controls themselves
    private void OnEnable()
    {
        playerControls.Enable();

    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    public Vector2 GetPlayerMovement()
    {
        return playerControls.ShrimpActionMap.Move.ReadValue<Vector2>();
        //returns the x (a/d) and (technically) z (w/d) of the keyboard. 
        //Third value is jump, which isnt controlled by WASD.
    }
    public float GetMouseDeltaHorizontal()
    {
        return playerControls.ShrimpActionMap.Look.ReadValue<Vector2>().x;
        //returns the horizontal input (x) of the mouse
    }
    public bool PlayerJumped()
    {
        return playerControls.ShrimpActionMap.Jump.triggered;
    }
    public bool PlayerInteracted()
    {
        return playerControls.ShrimpActionMap.Interact.triggered;
    }
    public bool PlayerCrouched()
    {
        return playerControls.ShrimpActionMap.Crouch.triggered;
    }

}
