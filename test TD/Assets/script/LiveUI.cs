using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LiveUI : MonoBehaviour
{
    public TMP_Text livesText;

    void Update()
    {
        livesText.text = PlayerStats.lives + " LIVES";
    }
}
