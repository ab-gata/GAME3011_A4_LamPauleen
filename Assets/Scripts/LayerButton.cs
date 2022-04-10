using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayerButton : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;

    private Color selectedColour;
    private Color normalColour;

    private Image buttonImage;
    
    private bool active = false;
    public bool Active { get { return active; } }

    // Start is called before the first frame update
    void Awake()
    {
        cube.SetActive(active);
        buttonImage = GetComponent<Image>();
        normalColour = new Color(100, 100, 100, 255);
        selectedColour = new Color(0, 255, 0, 255);
    }

    public void SwitchCube()
    {
        // Switch active bool
        active = !active;

        // Behaviour for each state
        if (active)
        {
            // Change button colour
            buttonImage.color = selectedColour;
        }
        else
        {
            // Change button colour
            buttonImage.color = normalColour;
        }

        // Show/hide cube
        cube.SetActive(active);
    }

    public void ResetButton()
    {
        buttonImage.color = normalColour;
    }
}
