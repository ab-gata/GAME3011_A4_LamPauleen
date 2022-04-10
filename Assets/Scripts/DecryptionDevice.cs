using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DecryptionDevice : MonoBehaviour
{
    [SerializeField]
    private GameObject decryptionGame;

    [SerializeField]
    private TextMeshProUGUI text;

    private bool complete = false;

    // Start is called before the first frame update
    void Start()
    {
        decryptionGame.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!complete)
        {
            gameObject.SetActive(false);
            decryptionGame.SetActive(true);
        }
    }

    public void CompleteHacking()
    {
        complete = true;
        text.text = "Agent: Looks like the data has been decrypted, nice work!";
        gameObject.SetActive(true);
        decryptionGame.SetActive(false);
    }
}
