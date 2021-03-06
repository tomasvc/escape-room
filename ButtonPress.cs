using UnityEngine;

public class ButtonPress : MonoBehaviour {

    public static bool button_pressed = false;
    public AudioSource audioSource;
    public static bool change_image = false;

	// Use this for initialization
	void Start () {

        button_pressed = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (button_pressed == true) {

            audioSource.Play();

            button_pressed = false;

        }

	}
}
