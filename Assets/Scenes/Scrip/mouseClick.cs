using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class mouseClick : MonoBehaviour
{
    public GameObject textNumber;

    private async void Start()
    {
        textNumber.SetActive(true);
        await Task.Delay(5000);
        textNumber.SetActive(false);
    }

    public void OnMouseDown()
    {
        textNumber.SetActive(true);
        Debug.Log("CLICK !!!!!!");
    }
}
