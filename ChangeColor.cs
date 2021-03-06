using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    /*  Changes material on panels inside Colour Puzzle  */

    public Material[] materials; // Array for storing materials
    public MeshRenderer meshRenderer;

    private int n = 0; // Used for counting

    public AudioSource audioSource;

    public GameObject button;

    public GameObject section; // Panel section

    public static bool top_solved;
    public static bool bottom_solved;
    public static bool left_solved;
    public static bool right_solved;

    // Start is called before the first frame update
    void Start()
    {

        top_solved = false;
        bottom_solved = false;
        left_solved = false;
        right_solved = false;

        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // For switching between colours, same as in Image Puzzle
        if (PlayerController.mouseClicked == true)
        {
            if (PlayerController.interactable.transform.name == button.transform.name)
            {
                audioSource.Play();

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

        }

        // If sections have correct colours, puzzle is solved
        if (section.name == "Top Panel" && meshRenderer.material.name == "White glass (Instance)")
        {
            top_solved = true;
        }

        if (section.gameObject.name == "Left Panel" && meshRenderer.material.name == "Red glass (Instance)")
        {
            left_solved = true;
        }

        if (section.gameObject.name == "Bottom Panel" && meshRenderer.material.name == "Yellow glass (Instance)")
        {
            bottom_solved = true;
        }

        if (section.gameObject.name == "Right Panel" && meshRenderer.material.name == "Blue glass (Instance)")
        {
            right_solved = true;
        }

    }
}
