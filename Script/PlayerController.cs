using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


    /* Controls the interaction between the player and the objects by using a
     * ray cast and retrieving information from any objects that can be used */


    public new Camera camera; // Camera object that is attached to the player
    private readonly float distance = 10; // Measures the distance between the player camera and the object
    public Image cursor; // Image that stores the cursor icon
    public static bool mouseClicked = false; // Boolean value that becomes true when mouse is clicked
    
    public static GameObject interactable; // Any object that the player is looking at and has a tag of "Useable" or "Object" will be stored in this game object

    Color cursorColor; // Colour of the cursor icon

    void Start()
    {
        mouseClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        cursorColor = cursor.color; // Assign a colour to cursorColor

        cursorColor.a = 0.1f; // Set its alpha to 0.1

        Ray ray = camera.ScreenPointToRay(Input.mousePosition); // Create a ray cast that goes from the camera to where the mouse is pointing, i.e. middle of the screen
        RaycastHit hit; // Get information from ray cast

        // If ray hits an object with the tag "Useable" or "Object", set cursor colour  to white, assign the game object to 'interactable' and set mouseClicked to true
        if (Physics.Raycast(ray, out hit, distance) && hit.transform.gameObject.tag == "Useable" ||
            Physics.Raycast(ray, out hit, distance) && hit.transform.gameObject.tag == "Object")
        {
            cursor.color = Color.white;
            interactable = hit.transform.gameObject;

            if (Input.GetMouseButtonDown(0) && !mouseClicked)
            {
                mouseClicked = true;
            }

        }
        // Otherwise set cursor's alpha back to 0.1
        else
        {
            cursor.color = cursorColor;
        }
    }
}
