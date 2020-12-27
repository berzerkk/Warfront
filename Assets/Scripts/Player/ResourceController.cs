using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResourceController : MonoBehaviour
{
    public TextMeshProUGUI woodCounter;
    public TextMeshProUGUI ironCounter;
    public int wood = 100;
    public int iron = 100;
    private void Update()
    {
        woodCounter.text = wood.ToString();
        ironCounter.text = iron.ToString();
    }
}
