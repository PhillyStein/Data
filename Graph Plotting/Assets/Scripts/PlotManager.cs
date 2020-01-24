using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlotManager : MonoBehaviour
{
    public TMP_InputField xInputField;
    public TMP_InputField yInputField;
    public GameObject graph;
    public GameObject plotPoint;
    public GameObject[] plots;
    public GameObject menuPanel;
    public TextMeshProUGUI menuButtonText;
    public GameObject newGraph;

    public int xAxis;
    public int yAxis;

    public int[] xPlotPos;
    public int[] yPlotPos;

    private bool menuAway = false;
    private bool graphExists = false;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel.transform.position = new Vector3(0f, menuPanel.transform.position.y, menuPanel.transform.position.z);
        GenerateGraph(12.0f, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ToggleMenu()
    {
        if (menuAway)
        {
            menuPanel.transform.position = new Vector3(menuPanel.transform.position.x + 140f, menuPanel.transform.position.y, menuPanel.transform.position.z);
            menuButtonText.SetText("<<");
        }
        else
        {
            menuPanel.transform.position = new Vector3(menuPanel.transform.position.x - 140f, menuPanel.transform.position.y, menuPanel.transform.position.z);
            menuButtonText.SetText(">>");
        }
        menuAway = !menuAway;
    }

    public void GenerateGraph(float xMax, float yMax)
    {
        if (!graphExists)
        {
            newGraph = Instantiate<GameObject>(graph);
            graphExists = true;
        }
        newGraph.transform.position = new Vector2(0f, 0f);
        newGraph.transform.localScale = new Vector2(xMax, yMax);
        Color lightGrey = new Color(0.9f, 0.9f, 0.9f, 1f);
        newGraph.GetComponent<SpriteRenderer>().color = lightGrey;
    }

    public void GenerateGraph()
    {
        float xMax = float.Parse(xInputField.text);
        float yMax = float.Parse(yInputField.text);

        GenerateGraph(xMax, yMax);
    }
}
