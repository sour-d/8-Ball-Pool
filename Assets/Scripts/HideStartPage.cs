using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideStartPage : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    
    public void Hide()
    {
        canvas.SetActive(false);
    }
}
