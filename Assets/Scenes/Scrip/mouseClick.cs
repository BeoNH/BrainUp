using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mouseClick : MonoBehaviour
{
    public GameObject textNumber;

    private void Start()
    {
        textNumber.SetActive(false);
    }

    public void OnMouseDown()
    {
        textNumber.SetActive(true);
        Debug.Log("CLICK !!!!!!");
    }
}
