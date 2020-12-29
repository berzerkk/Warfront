using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResourceController : MonoBehaviour
{
    public TextMeshProUGUI woodCounter;
    public TextMeshProUGUI ironCounter;
    private void Update()
    {
        woodCounter.text = SavedVariables.woodCounter.ToString();
        ironCounter.text = SavedVariables.ironCounter.ToString();
    }
}
