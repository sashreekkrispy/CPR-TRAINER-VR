using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hoverOver : MonoBehaviour
{

    [SerializeField] private Button b1;
    [SerializeField] private Color wantedHoverColor;
    private Color currColor;
    private ColorBlock cb;

    // Start is called before the first frame update
    void Start()
    {
        cb = b1.colors;
        currColor = cb.selectedColor;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeWhenHover()
    {
        cb.selectedColor = wantedHoverColor;
        b1.colors = cb;
    }
    public void changeWhenLeaves()
    {
        cb.selectedColor = currColor;
        b1.colors = cb;
    }
}
