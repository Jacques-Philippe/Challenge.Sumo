using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    
    public void ApplyPowerup(IEnumerator powerup)
    {
        StartCoroutine(powerup);
    }
}
