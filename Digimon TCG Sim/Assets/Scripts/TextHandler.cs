using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHandler : MonoBehaviour
{
    public TMP_Text turn;
    public TMP_Text phase;
    public TMP_Text decision_next;

    void Update()
    {
        turn.text = $"Turn: {GameSetup.turnNumber}";
        phase.text = $"Phase: {GameSetup.curPhase}";
        decision_next.text = $"{GameFlow.buttonText}";
    }
}
