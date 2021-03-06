using UnityEngine;

public class PlaySound : MonoBehaviour
{

    public AudioSource audioSource;
    AudioClip audioClip;

    bool trigger1, trigger2, trigger3, trigger4, trigger5, trigger6, trigger7, trigger8;

    // Start is called before the first frame update
    void Start()
    {
        trigger1 = false;
        trigger2 = false;
        trigger3 = false;
        trigger4 = false;
        trigger5 = false;
        trigger6 = false;
        trigger7 = false;
        trigger8 = false;
    }

    void Sound(bool condition) 
    {
        if (condition)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!trigger1)
        {
            Sound(ImagePuzzle.part1_solved);
            trigger1 = true;
        }

        if (!trigger2)
        {
            Sound(ImagePuzzle.part2_solved);
            trigger2 = true;
        }
        

    }
}
