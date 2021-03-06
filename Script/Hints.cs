using System.Collections;
using UnityEngine;
using TMPro;

public class Hints : MonoBehaviour
{
    public GameObject canvas, text;

    bool hintActive = false;
    
    IEnumerator Hint()
    {
        hintActive = true;

        canvas.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        canvas.SetActive(false);

        hintActive = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hintActive && Input.GetKey(KeyCode.H))
        {
            StartCoroutine(Hint());
        }

        if(!ImagePuzzle.part1_solved)
        {
            text.GetComponent<TextMeshProUGUI>().text = "These paintings look interesting. Perhaps there's something more to them.";

        }
        else if (!ImagePuzzle.part2_solved)
        {
            text.GetComponent<TextMeshProUGUI>().text = "These images behind the painting seem to have a pattern. I wonder if I can change them.";
        }
        else if (!ColorPuzzle.part1_solved)
        {
            text.GetComponent<TextMeshProUGUI>().text = "What is that behind the wardrobe? It looks like it's missing something.";
        }
        else if (!ColorPuzzle.part2_solved)
        {
            text.GetComponent<TextMeshProUGUI>().text = "These colors seem familiar.";
        }
        else if (!PlatformPuzzle.part1_solved)
        {
            text.GetComponent<TextMeshProUGUI>().text = "The table in the middle of the room has three holes in it. Do I have to put something in?";
        }
        else if (!PlatformPuzzle.part2_solved)
        {
            text.GetComponent<TextMeshProUGUI>().text = "The spheres light up when I touch them but turn red if I do it too many times.";
        }
        else if (EndRoom.player_inside)
        {
            text.GetComponent<TextMeshProUGUI>().text = "What is that on the wall?";
        }

        if (EndRoom.start)
        {
            text.GetComponent<TextMeshProUGUI>().text = "Oh no . . .";
        }

    }
}
