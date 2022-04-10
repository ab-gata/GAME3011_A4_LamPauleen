using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    enum Difficulty
    { 
        EASY,
        MEDIUM,
        HARD
    }

    // UI Guide Elements
    [SerializeField, Header("UI Elements")]
    Dropdown dropdown;
    [SerializeField]
    Image image;

    // Guide images
    [SerializeField, Header("Guide Images")]
    Sprite easyGuide;
    [SerializeField]
    Sprite mediumGuide;
    [SerializeField]
    Sprite hardGuide;

    // WinLose UI
    [SerializeField, Header("Win/Lose UI")]
    GameObject winLoseUI;
    

    // Cube components
    [SerializeField, Header("CubeSets")]
    private GameObject cubeSetLayer1;
    [SerializeField]
    private GameObject cubeSetLayer2;
    [SerializeField]
    private GameObject cubeSetLayer3;
    [SerializeField]
    private GameObject cubeSetLayer4;

    // Layer button components
    [SerializeField, Header("Buttons")]
    private GameObject buttonGrid1;
    [SerializeField]
    private GameObject buttonGrid2;
    [SerializeField]
    private GameObject buttonGrid3;
    [SerializeField]
    private GameObject buttonGrid4;

    // List of all cubes/buttons
    private List<GameObject> cubeSet = new List<GameObject>();
    private List<LayerButton> buttons = new List<LayerButton>();

    // List of bools for each solution
    private List<bool> easySolution = new List<bool>();
    private List<bool> mediumSolution = new List<bool>();
    private List<bool> hardSolution = new List<bool>();

    // Player difficulty setting
    private Difficulty difficulty = Difficulty.EASY;

    // Start is called before the first frame update
    void Start()
    {
        // Add all cubes to one list
        foreach (Transform child in cubeSetLayer4.transform)
        {
            cubeSet.Add(child.gameObject);
        }
        foreach (Transform child in cubeSetLayer3.transform)
        {
            cubeSet.Add(child.gameObject);
        }
        foreach (Transform child in cubeSetLayer2.transform)
        {
            cubeSet.Add(child.gameObject);
        }
        foreach (Transform child in cubeSetLayer1.transform)
        {
            cubeSet.Add(child.gameObject);
        }

        // Add all buttons to one list
        foreach (Transform child in buttonGrid4.transform)
        {
            buttons.Add(child.GetComponent<LayerButton>());
        }
        foreach (Transform child in buttonGrid3.transform)
        {
            buttons.Add(child.GetComponent<LayerButton>());
        }
        foreach (Transform child in buttonGrid2.transform)
        {
            buttons.Add(child.GetComponent<LayerButton>());
        }
        foreach (Transform child in buttonGrid1.transform)
        {
            buttons.Add(child.GetComponent<LayerButton>());
        }

        CreateSolutions();

        // Add dropdown listener
        dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown); });
    }

    public void CheckSolution()
    {
        List<bool> solution = new List<bool>();
        bool errors = false;

        switch (difficulty)
        {
            case Difficulty.EASY:
                solution = easySolution;
                break;
            case Difficulty.MEDIUM:
                solution = mediumSolution;
                break;
            case Difficulty.HARD:
                solution = hardSolution;
                break;
        }

        for (int i = 0; i < solution.Count; i++)
        {
            if (solution[i] != cubeSet[i].activeSelf)
            {
                errors = true;
            }
        }

        if (errors)
        {
            winLoseUI.GetComponent<WinLoseObject>().ShowLose();
        }
        else
        {
            winLoseUI.GetComponent<WinLoseObject>().ShowWin();
        }
    }

    public void ResetGame()
    {
        // Clear cubes
        foreach (var item in cubeSet)
        {
            item.SetActive(false);
        }

        // Clear buttons
        foreach (var item in buttons)
        {
            item.ResetButton();
        }

        // Clear winLoseUI
        winLoseUI.GetComponent<WinLoseObject>().Clear();
    }

    void DropdownValueChanged(Dropdown change)
    {
        Debug.Log(change.value);

        switch (change.value)
        {
            case 0:
                difficulty = Difficulty.EASY;
                image.sprite = easyGuide;
                break;
            case 1:
                difficulty = Difficulty.MEDIUM;
                image.sprite = mediumGuide;
                break;
            case 2:
                difficulty = Difficulty.HARD;
                image.sprite = hardGuide;
                break;
        }

        ResetGame();
    }

    private void CreateSolutions()
    {
        // Create EASY SOLUTION
        easySolution.Add(true); easySolution.Add(true); easySolution.Add(true); easySolution.Add(true);
        easySolution.Add(true); easySolution.Add(false); easySolution.Add(false); easySolution.Add(true);
        easySolution.Add(true); easySolution.Add(true); easySolution.Add(true); easySolution.Add(true);

        easySolution.Add(false); easySolution.Add(false); easySolution.Add(false); easySolution.Add(false);
        easySolution.Add(true); easySolution.Add(false); easySolution.Add(false); easySolution.Add(true);
        easySolution.Add(false); easySolution.Add(false); easySolution.Add(false); easySolution.Add(false);

        easySolution.Add(false); easySolution.Add(false); easySolution.Add(false); easySolution.Add(false);
        easySolution.Add(true); easySolution.Add(false); easySolution.Add(false); easySolution.Add(true);
        easySolution.Add(false); easySolution.Add(false); easySolution.Add(false); easySolution.Add(false);
 
        easySolution.Add(true); easySolution.Add(true); easySolution.Add(true); easySolution.Add(true);
        easySolution.Add(true); easySolution.Add(true); easySolution.Add(true); easySolution.Add(true);
        easySolution.Add(true); easySolution.Add(true); easySolution.Add(true); easySolution.Add(true);

        // Create MEDIUM SOLUTION
        mediumSolution.Add(true); mediumSolution.Add(false); mediumSolution.Add(false); mediumSolution.Add(true);
        mediumSolution.Add(true); mediumSolution.Add(true); mediumSolution.Add(false); mediumSolution.Add(true);
        mediumSolution.Add(true); mediumSolution.Add(false); mediumSolution.Add(false); mediumSolution.Add(true);
                           
        mediumSolution.Add(true); mediumSolution.Add(false); mediumSolution.Add(false); mediumSolution.Add(false);
        mediumSolution.Add(true); mediumSolution.Add(true); mediumSolution.Add(false); mediumSolution.Add(false);
        mediumSolution.Add(true); mediumSolution.Add(false); mediumSolution.Add(false); mediumSolution.Add(false);
                           
        mediumSolution.Add(true); mediumSolution.Add(false); mediumSolution.Add(false); mediumSolution.Add(false);
        mediumSolution.Add(true); mediumSolution.Add(false); mediumSolution.Add(true); mediumSolution.Add(false);
        mediumSolution.Add(true); mediumSolution.Add(false); mediumSolution.Add(false); mediumSolution.Add(false);
                           
        mediumSolution.Add(true); mediumSolution.Add(false); mediumSolution.Add(false); mediumSolution.Add(true);
        mediumSolution.Add(true); mediumSolution.Add(false); mediumSolution.Add(true); mediumSolution.Add(true);
        mediumSolution.Add(true); mediumSolution.Add(false); mediumSolution.Add(false); mediumSolution.Add(true);

        // Create HARD SOLUTION
        hardSolution.Add(false); hardSolution.Add(true); hardSolution.Add(true); hardSolution.Add(false);
        hardSolution.Add(true); hardSolution.Add(false); hardSolution.Add(true); hardSolution.Add(true);
        hardSolution.Add(true); hardSolution.Add(false); hardSolution.Add(false); hardSolution.Add(true);

        hardSolution.Add(false); hardSolution.Add(false); hardSolution.Add(true); hardSolution.Add(false);
        hardSolution.Add(true); hardSolution.Add(false); hardSolution.Add(false); hardSolution.Add(false);
        hardSolution.Add(true); hardSolution.Add(true); hardSolution.Add(true); hardSolution.Add(true);

        hardSolution.Add(true); hardSolution.Add(true); hardSolution.Add(true); hardSolution.Add(false);
        hardSolution.Add(false); hardSolution.Add(false); hardSolution.Add(false); hardSolution.Add(true);
        hardSolution.Add(true); hardSolution.Add(false); hardSolution.Add(false); hardSolution.Add(true);

        hardSolution.Add(true); hardSolution.Add(true); hardSolution.Add(false); hardSolution.Add(false);
        hardSolution.Add(false); hardSolution.Add(false); hardSolution.Add(false); hardSolution.Add(true);
        hardSolution.Add(true); hardSolution.Add(false); hardSolution.Add(false); hardSolution.Add(false);
    }


    // Remove listener just in case...
    private void OnDestroy()
    {
        dropdown.onValueChanged.RemoveListener(delegate { DropdownValueChanged(dropdown); });
    }
}
