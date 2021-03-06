using System.Collections;
using UnityEngine;

public class PlatformPuzzle : MonoBehaviour {


    /* Controls the Platform Puzzle */

    // For tracking the sate of the puzzle
    public static bool part1_solved;
    public static bool part2_solved;
    public static bool door_button_pressed;

    public bool found = false; // Becomes true when all spheres are placed on table

    public Material glowMaterial, glassMaterial, redMaterial; // Materials for spheres

    public GameObject tableSlot_1, tableSlot_2, tableSlot_3; // Slots for spheres to go in
    public GameObject doorButton; // Button found in the center
    public GameObject light_1, light_2, light_3, light_4; // Lights used for flickering

    GameObject sphere_1, sphere_2, sphere_3;

    int count_1, count_2, count_3; // Used for counting shpere taps

    bool sphere_1_solved, sphere_2_solved, sphere_3_solved; // Become true if spheres are tapped enough times
    bool sphere_1_stop, sphere_2_stop, sphere_3_stop; // Used to stop the spheres from blinking

    bool waitActive, clickActive, flickerActive; // Used as triggers for Enumerators

    AudioSource audioSource;

    // make spheres flash red for 2 seconds
    IEnumerator RedFlash()
    {

        waitActive = true;

        sphere_1 = GameObject.Find("Sphere 1(Clone)");
        sphere_2 = GameObject.Find("Sphere 2(Clone)");
        sphere_3 = GameObject.Find("Sphere 3(Clone)");

        sphere_1.GetComponent<MeshRenderer>().material = redMaterial;
        sphere_2.GetComponent<MeshRenderer>().material = redMaterial;
        sphere_3.GetComponent<MeshRenderer>().material = redMaterial;

        yield return new WaitForSeconds(2.0f);

        sphere_1.GetComponent<MeshRenderer>().material = glassMaterial;
        sphere_2.GetComponent<MeshRenderer>().material = glassMaterial;
        sphere_3.GetComponent<MeshRenderer>().material = glassMaterial;

        waitActive = false;
        
    }

    // make spheres flash white for half a second
    IEnumerator WhiteFlash()
    {
        clickActive = true;

        if (!waitActive)
        {
            PlayerController.interactable.GetComponent<MeshRenderer>().material = glowMaterial;
        }

        yield return new WaitForSeconds(0.5f);

        if (!waitActive)
        {
            PlayerController.interactable.GetComponent<MeshRenderer>().material = glassMaterial;
        }

        clickActive = false;
    }

    // make lights flicker
    IEnumerator Flicker()
    {
        flickerActive = true;

        light_1.GetComponent<Light>().enabled = false;
        light_2.GetComponent<Light>().enabled = false;
        light_3.GetComponent<Light>().enabled = false;
        light_4.GetComponent<Light>().enabled = false;

        yield return new WaitForSeconds(0.2f);

        light_1.GetComponent<Light>().enabled = true;
        light_2.GetComponent<Light>().enabled = true;
        light_3.GetComponent<Light>().enabled = true;
        light_4.GetComponent<Light>().enabled = true;

        yield return new WaitForSeconds(0.2f);

        light_1.GetComponent<Light>().enabled = false;
        light_2.GetComponent<Light>().enabled = false;
        light_3.GetComponent<Light>().enabled = false;
        light_4.GetComponent<Light>().enabled = false;

    }

    // Use this for initialization
    void Start () {

        part1_solved = false;
        part2_solved = false;
        door_button_pressed = false;

        sphere_1_solved = false;
        sphere_2_solved = false;
        sphere_3_solved = false;

        sphere_1_stop = false;
        sphere_2_stop = false;
        sphere_3_stop = false;

        waitActive = false;
        clickActive = false;
        flickerActive = false;

        audioSource = GetComponent<AudioSource>();

	}

    // Update is called once per frame
    void Update () {

        // check if table contains all spheres
        if (!found)
        {
            if (GameObject.Find("Sphere 1(Clone)") != null && GameObject.Find("Sphere 2(Clone)") != null && GameObject.Find("Sphere 3(Clone)") != null)
            {
                part1_solved = true;
                Destroy(tableSlot_1);
                Destroy(tableSlot_2);
                Destroy(tableSlot_3);
                found = true;
                return;
            }
        }

        // if all spheres are placed on table
        if (PlayerController.interactable != null && !part2_solved && found)
        {
            if (PlayerController.interactable.name == "Sphere 1(Clone)" ||
            PlayerController.interactable.name == "Sphere 2(Clone)" ||
            PlayerController.interactable.name == "Sphere 3(Clone)")

            // flash sphere if mouse is clicked
            {
                if (!waitActive)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (!clickActive)
                        {
                            StartCoroutine(WhiteFlash());
                        }
                    }
                }
                
                // if player taps on Sphere 1, increase count; if count is 2, mark as solved; if count is more than 2, flash red, reset count on all spheres
                if (PlayerController.interactable.name == "Sphere 1(Clone)" && PlayerController.mouseClicked && !sphere_1_stop)
                {
                    count_1++;

                    if (count_1 == 2)
                    {
                        sphere_1_solved = true;
                    }
                    else if (count_1 > 2)
                    {
                        if (!waitActive)
                        {
                            StartCoroutine(RedFlash());
                        }

                        count_1 = 0;
                        count_2 = 0;
                        count_3 = 0;

                        sphere_1_solved = false;
                        sphere_2_solved = false;
                        sphere_3_solved = false;
                    }

                    PlayerController.mouseClicked = false;

                }

                // if player taps on Sphere 2, increase count; if count is 3, mark as solved; if count is more than 3, flash red, reset count on all spheres
                if (PlayerController.interactable.name == "Sphere 2(Clone)" && PlayerController.mouseClicked && !sphere_2_stop)
                {
                    count_2++;

                    if (count_2 == 3)
                    {
                        sphere_2_solved = true;
                    }
                    else if (count_2 > 3)
                    {
                        if (!waitActive)
                        {
                            StartCoroutine(RedFlash());
                        }

                        count_1 = 0;
                        count_2 = 0;
                        count_3 = 0;

                        sphere_1_solved = false;
                        sphere_2_solved = false;
                        sphere_3_solved = false;
                    }

                    PlayerController.mouseClicked = false;

                }

                // if player taps on Sphere 3, increase count; if count is 5, mark as solved; if count is more then 5, flash red, reset count on all spheres
                if (PlayerController.interactable.name == "Sphere 3(Clone)" && PlayerController.mouseClicked && !sphere_3_stop)
                {
                    count_3++;

                    if (count_3 == 5)
                    {
                        sphere_3_solved = true;
                    }
                    else if (count_3 > 5)
                    {
                        if (!waitActive)
                        {
                            StartCoroutine(RedFlash());
                        }

                        count_1 = 0;
                        count_2 = 0;
                        count_3 = 0;

                        sphere_1_solved = false;
                        sphere_2_solved = false;
                        sphere_3_solved = false;
                    }

                    PlayerController.mouseClicked = false;

                }

                // if all spheres are solved, the puzzle becomes solved
                if (sphere_1_solved && sphere_2_solved && sphere_3_solved && part1_solved && !part2_solved)
                {
                    sphere_1_stop = true;
                    sphere_2_stop = true;
                    sphere_3_stop = true;

                    sphere_1 = GameObject.Find("Sphere 1(Clone)");
                    sphere_2 = GameObject.Find("Sphere 2(Clone)");
                    sphere_3 = GameObject.Find("Sphere 3(Clone)");

                    PlayerController.mouseClicked = false;

                    sphere_1.GetComponent<MeshRenderer>().material = glowMaterial;
                    sphere_2.GetComponent<MeshRenderer>().material = glowMaterial;
                    sphere_3.GetComponent<MeshRenderer>().material = glowMaterial;

                    part2_solved = true;

                }
            }

        }

        // if puzzle is solved and door button is pressed, flash lights and open door
        if (part2_solved)
        {
            if (PlayerController.interactable.name == "Door Button" && PlayerController.mouseClicked)
            {
                door_button_pressed = true;
                ButtonPress.button_pressed = true;

                if (!flickerActive)
                {
                    StartCoroutine(Flicker());
                }

                PlayerController.mouseClicked = false;
            }
        }

    }
}
