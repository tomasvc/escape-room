using UnityEngine;

public class ColorPuzzle : MonoBehaviour
{

    /* Contains the majority of the game objects and booleans
     * required for this puzzle. Tracks the completion. */
    
    // Booleans that become true once all gems are placed on puzzle
    public static bool redSlot;
    public static bool blueSlot;
    public static bool yellowSlot;

    // Game objects for coloured panels inside puzzle
    public GameObject topPanel;
    public GameObject bottomPanel;
    public GameObject leftPanel;
    public GameObject rightPanel;

    public GameObject centerButton;

    public static bool part1_solved;
    public static bool part2_solved;

    public static bool center_button;

    // Start is called before the first frame update
    void Start()
    {

        redSlot = false;
        blueSlot = false;
        yellowSlot = false;

        part1_solved = false;
        part2_solved = false;

        center_button = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // If all three gemstones are placed on the puzzle, part 1 is solved
        if (redSlot == true && blueSlot == true && yellowSlot == true)
        {
            part1_solved = true;
        }

        // If all colours on the panels are correct, part 2 is solved
        if (ChangeColor.top_solved == true && ChangeColor.bottom_solved == true &&
            ChangeColor.left_solved == true && ChangeColor.right_solved == true)
        {
            part2_solved = true;
        }
        
        // For the center button
        if (PlayerController.mouseClicked == true)
        {
            if (PlayerController.interactable.transform.name == centerButton.transform.name)
            {
                center_button = true;
                ButtonPress.button_pressed = true;
                PlayerController.mouseClicked = false;
            }
        }

    }
}
