//   _  _    _____       _       _____ _             _ _       
// _| || |_ / ____|     | |     / ____| |           | (_)      
//|_  __  _| (___   ___ | | ___| (___ | |_ _   _  __| |_  ___  
// _| || |_ \___ \ / _ \| |/ _ \\___ \| __| | | |/ _` | |/ _ \ 
//|_  __  _|____) | (_) | | (_) |___) | |_| |_| | (_| | | (_) |
//  |_||_| |_____/ \___/|_|\___/_____/ \__|\__,_|\__,_|_|\___/ 

using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotationSpeed = 2.0f; // Adjust the rotation speed as needed.
    
    private float yaw = 0.0f;
    private bool isCursorVisible = false;

    void Start()
    {
        // Lock and hide the cursor initially.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Toggle cursor visibility when the "Q" key is pressed.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isCursorVisible = !isCursorVisible;
            
            if (isCursorVisible)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        // Get mouse input for camera rotation on the Y-axis.
        float mouseX = Input.GetAxis("Mouse X");
        yaw += mouseX * rotationSpeed;

        // Apply rotation to the camera only on the Y-axis.
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
}
//SoloStudio-2024
