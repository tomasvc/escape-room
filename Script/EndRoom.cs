using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRoom : MonoBehaviour
{

    /*  Controls the events in final room  */

    public GameObject wall, player, playerController, blackCanvas, credits, sound, crush; 

    float distance; // Tracks distance between player and wall with sign

    bool crushActive = false;

    public static bool player_inside, start;

    public Animator wall_1, wall_2, wall_3, door_1, door_2;

    public AudioSource audioSource, audioSource_wall, audioSource_door, audioSource_crush;
    public AudioClip wall_clip, door_clip, crush_clip;

    bool canvasOn = false;

    bool trigger1 = false, trigger2 = false, trigger3 = false;

    bool play = false;

    // Walls move in between pauses, when the last wall crushes player, cut to black, display credits, go back to menu
    IEnumerator Crush()
    {
        crushActive = true;

        yield return new WaitForSeconds(3.0f);

        playAnimation(wall_1, "Wall 1 Move 1", wall_clip);

        yield return new WaitForSeconds(3.0f);

        playAnimation(wall_2, "Wall 2 Move 1", wall_clip);

        yield return new WaitForSeconds(3.0f);

        playAnimation(wall_3, "Wall 3 Move 1", wall_clip);

        yield return new WaitForSeconds(3.0f);

        playAnimation(wall_1, "Wall 1 Move 2", wall_clip);

        yield return new WaitForSeconds(3.0f);

        playAnimation(wall_2, "Wall 2 Move 2", wall_clip);

        yield return new WaitForSeconds(3.0f);

        playAnimation(wall_3, "Wall 3 Move 2", wall_clip);

        yield return new WaitForSeconds(3.0f);

        playAnimation(wall_1, "Wall 1 Move 3", wall_clip);

        yield return new WaitForSeconds(3.0f);

        playAnimation(wall_2, "Wall 2 Move 3", wall_clip);

        yield return new WaitForSeconds(5.0f);

        playAnimation(wall_3, "Wall 3 Move 3", wall_clip);

        yield return new WaitForSeconds(3.0f);

        blackCanvas.SetActive(true);

        canvasOn = true;

        yield return new WaitForSeconds(3.0f);

        credits.SetActive(true);

        yield return new WaitForSeconds(3.0f);

        credits.SetActive(false);

        SceneManager.LoadScene("Menu");

    }

    // Start is called before the first frame update
    void Start()
    {

        crushActive = false;
        player_inside = false;
        start = false;

        blackCanvas.SetActive(false);
        credits.SetActive(false);
    }

    void playAnimation(Animator animator, string trigger, AudioClip clip)
    {
        Debug.Log("Playing");
        play = true;

        animator.SetTrigger(trigger);

        if (audioSource != null && play)
        {
            audioSource_wall.PlayOneShot(clip);
            play = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (canvasOn)
        {
            if (!trigger3)
            {
                audioSource_crush.PlayOneShot(crush_clip);
                trigger3 = true;
            }
        }

        distance = Vector3.Distance(wall.transform.position, player.transform.position);

        // if distance between player and wall is 25, play music
        if (distance <= 15)
        {
            start = true;
        }
        // if distance is less than 45, it means player is inside room
        else if (distance <= 45)
        {
            player_inside = true;
        }
        // if sound is playing, begin wall animaions
        if (start && !crushActive)
        {
            StartCoroutine(Crush());
        }
        // if player is getting further from the wall, or closer to the doors, shut doors
        if (start && distance >= 35)
        {
            if (!trigger2)
            {
                playAnimation(door_1, "Close Door", door_clip);
                playAnimation(door_2, "Close Door", null);
                trigger2 = true;
            }
        }
        // play scary music
        if (start)
        {
            if (audioSource.clip.name == "scaryscape" && !trigger1)
            {
                audioSource.Play();

                trigger1 = true;
            }
            
        }

    }
}
