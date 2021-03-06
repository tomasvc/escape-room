using UnityEngine;

public class ImagePuzzle : MonoBehaviour
{


    /* Controls the Image Puzzle, the buttons and rendering of materials,
     * i.e., the images. Designed to be used for all three image frames */


    public Material[] materials; // An array that stores all the available image materials in each row
    public MeshRenderer meshRenderer; // Mesh renderer of the image frame
    private int n = 0; // Integer that will be used to count between images

    public GameObject leftButton;
    public GameObject rightButton;

    public GameObject topImage;
    public GameObject middleImage;
    public GameObject bottomImage;

    // Used to keep track of puzzle progression
    public static bool part1_solved;
    public static bool part2_solved;

	// Use this for initialization
	void Start () {

        part1_solved = false;
        part2_solved = false;

        meshRenderer = GetComponent<MeshRenderer>();

    }
	
	// Update is called once per frame
	void Update () {

        // If mouse is clicked
        if (PlayerController.mouseClicked == true)
        {
            // If 'interactable' is not empty and its name is "Puzzle painting"
            if (PlayerController.interactable != null && PlayerController.interactable.name == "Puzzle_painting")
            {
                part1_solved = true; // Painting is removed
            }

            // If player is looking at an object named "Right Button", button is pressed and image is changed to the next one
            if (PlayerController.interactable.transform.name == rightButton.transform.name)
            {
                ButtonPress.button_pressed = true;

                if (n >= 3)
                {
                    n = 0;
                }
                else
                {
                    n++;
                }

                meshRenderer.material = materials[n];
                PlayerController.mouseClicked = false;

            }
            // If player is looking at an object named "Left Button", button is pressed and image is changed to the previous one
            if (PlayerController.interactable.transform.name == leftButton.transform.name)
            {
                ButtonPress.button_pressed = true;

                if (n <= 0)
                {
                    n = 3;
                }
                else
                {
                    n--;
                }

                meshRenderer.material = materials[n];
                PlayerController.mouseClicked = false;

            }
            
        }

        // If all three images have been correctly picked, the puzzle is solved
        if (topImage.GetComponent<MeshRenderer>().material.name == "img-3-1 (Instance)" && 
            middleImage.GetComponent<MeshRenderer>().material.name == "img-4-1 (Instance)" && 
            bottomImage.GetComponent<MeshRenderer>().material.name == "img-8-1 (Instance)")
        {
            part2_solved = true;     
        }

    }
}
