using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public delegate void OnEnemyDeathAction();
    public OnEnemyDeathAction OnEnemyDeath;

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
        OnEnemyDeath.Invoke();
        GameObject.Destroy(this.gameObject);
    }
}
