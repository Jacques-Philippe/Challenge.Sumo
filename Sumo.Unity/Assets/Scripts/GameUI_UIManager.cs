using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI_UIManager : MonoBehaviour
{
    /// <summary>
    /// The UI element containing the text where state information is displayed
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI text;

    /// <summary>
    /// The value of the current wave
    /// </summary>
    private int waveNumber;

    /// <summary>
    /// The public-facing accessor and mutator for the value. <br />
    /// </summary>
    /// <remarks>Changing this value will update the UI</remarks>
    public int WaveNumber
    {
        get => waveNumber;
        set
        {
            this.ThreadsafeUpdate(newValue: value);
            this.waveNumber = value;
        }
    }

    /// <summary>
    /// A queue to contain all enqueued text to update the UI with
    /// </summary>
    /// <remarks>this is done so that updates to the UI are made properly</remarks>
    protected ConcurrentQueue<string> mQueuedText = new ConcurrentQueue<string>();


    void ThreadsafeUpdate(int newValue)
    {
        mQueuedText.Enqueue($"{newValue}");
    }

    protected virtual void UpdateText()
    {
        string newValue;
        while (mQueuedText.TryDequeue(out newValue))
        {
            text.text = $"Wave {newValue}";
        }
    }

    private void Update()
    {
        UpdateText();
    }
}
