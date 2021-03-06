using UnityEngine;

public class startAnimation : MonoBehaviour {

    Animator anim;

    public AudioSource audioSource;
    public AudioClip audioClip;

    private bool trigger1 = true;
    private bool trigger2 = true;
    private bool trigger3 = true;
    private bool trigger4 = true;
    private bool trigger5 = true;
    private bool trigger6 = true;
    private bool trigger7 = true;
    private bool trigger8 = true;

    private bool play;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        
    }

    void playAnimation(bool is_solved, string trigger)
    {
        play = true;

        if (is_solved == true && play == true)
        {
            anim.SetTrigger(trigger);

            play = false;
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update() {

        if (ImagePuzzle.part1_solved == true && trigger1 == true)
        {
            anim.SetTrigger("Painting");
            PlayerController.mouseClicked = false;
            trigger1 = false;
        }

        if (ImagePuzzle.part2_solved == true && trigger2 == true)
        {
            if (audioSource != null && audioSource.clip.name == "mystery_peak")
            {
                audioSource.Play();
            }

            if (audioSource != null && audioSource.clip.name == "lock")
            {
                audioSource.Play();
            }

            if (audioSource != null && audioClip != null && audioSource.clip.name == "mechanical")
            {
                audioSource.PlayOneShot(audioClip, 0.2f);
            }

            playAnimation(ImagePuzzle.part2_solved, "Move");
            playAnimation(ImagePuzzle.part2_solved, "Wardrobe");
            trigger2 = false;
        }

        if (ColorPuzzle.part1_solved == true && trigger3 == true)
        {
            if (audioSource != null && audioSource.clip.name == "door_open")
            {
                audioSource.Play();
            }

            playAnimation(ColorPuzzle.part1_solved, "Start");
            trigger3 = false;
        }

        if (ColorPuzzle.part2_solved == true && trigger4 == true)
        {
            if (audioSource != null && audioSource.clip.name == "mystery_peak")
            {
                audioSource.Play();
            }

            if (audioSource != null && audioSource.clip.name == "lock")
            {
                audioSource.Play();
            }

            playAnimation(ColorPuzzle.part2_solved, "Open");
            trigger4 = false;
        }

        if (ColorPuzzle.center_button == true && trigger5 == true)
        {
            if (audioSource != null && audioClip != null && audioSource.clip.name == "mechanical_3")
            {
                audioSource.PlayOneShot(audioClip, 0.5f);
            }

            playAnimation(ColorPuzzle.center_button, "Descend");
            trigger5 = false;
        }

        if (PlatformPuzzle.part1_solved == true && trigger6 == true)
        {
            if (audioSource != null && audioClip != null && audioSource.clip.name == "mechanical")
            {
                audioSource.PlayOneShot(audioClip, 0.2f);
            }

            playAnimation(PlatformPuzzle.part1_solved, "Rise");
            trigger6 = false;
        }

        if (PlatformPuzzle.part2_solved == true && trigger7 == true)
        {
            if (audioSource != null && audioClip != null && audioSource.clip.name == "mechanical_2")
            {
                audioSource.PlayOneShot(audioClip, 0.2f);
            }

            playAnimation(PlatformPuzzle.part2_solved, "Down");
            playAnimation(PlatformPuzzle.part2_solved, "Open Final");
            trigger7 = false;
        }

        if (PlatformPuzzle.door_button_pressed == true && trigger8 == true)
        {
            if (audioSource != null && audioSource.clip.name == "door_open")
            {
                audioSource.Play();
            }

            if (audioSource != null && audioSource.clip.name == "mystery_peak_2")
            {
                audioSource.Play();
            }

            playAnimation(PlatformPuzzle.door_button_pressed, "Open Door");
            trigger8 = false;
        }

    }
}
