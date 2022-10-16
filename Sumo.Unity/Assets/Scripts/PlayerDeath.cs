using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Kill the player if they get knocked off the arena and fall below a certain height
/// </summary>
public class PlayerDeath : MonoBehaviour
{
    public delegate void OnPlayerDeathAction();
    public OnPlayerDeathAction OnPlayerDeath;

    /// <summary>
    /// The threshold (on the Y axis) below which the player is killed
    /// </summary>
    private float verticalThreshold = -4.0f;
    private void Start()
    {
        StartCoroutine(KillOnThresholdPass());
    }

    private IEnumerator KillOnThresholdPass()
    {
        yield return new WaitUntil(() =>
        {
            var currentY = this.transform.position.y;
            return currentY < this.verticalThreshold;
        });
        OnPlayerDeath.Invoke();
        GameObject.Destroy(this.gameObject);
    }

}
