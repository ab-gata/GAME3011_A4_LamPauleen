using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

enum ObjectState
{
    WIN, LOSE, NONE
}

public class WinLoseObject : MonoBehaviour
{
    [SerializeField]
    private GameObject background;
    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    private string winText = "DECRYPTION SUCCESS";
    [SerializeField]
    private string loseText = "!DECRYPTION ERROR!";

    [SerializeField]
    private DecryptionDevice decryptionDevice;

    private float timer;
    private ObjectState state = ObjectState.NONE;

    // Start is called before the first frame update
    void Start()
    {
        background.SetActive(false);
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (state != ObjectState.NONE)
        {
            timer += Time.deltaTime;

            if (state == ObjectState.LOSE)
            {
                if (timer > 2.5f)
                {
                    Clear();
                }
            }
            if (state == ObjectState.WIN)
            {
                if (timer > 2.5f)
                {
                    Clear();
                    decryptionDevice.CompleteHacking();
                }
            }
        }
    }

    public void ShowWin()
    {
        state = ObjectState.WIN;
        background.SetActive(true);
        text.text = winText;
        timer = 0.0f;
    }

    public void ShowLose()
    {
        state = ObjectState.LOSE;
        background.SetActive(true);
        text.text = loseText;
        timer = 0.0f;
    }

    public void Clear()
    {
        state = ObjectState.NONE;
        background.SetActive(false);
        text.text = "";
    }
}
