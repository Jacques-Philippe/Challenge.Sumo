using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PickupPowerup : MonoBehaviour
{
    /// <summary>
    /// Duration of the powerup in seconds
    /// </summary>
    private float powerupDuration = 5.0f;

    private IEnumerator PowerUpEffect(GameObject player)
    {
        var collider = player.GetComponent<SphereCollider>();
        var initialBounciness = collider.material.bounciness;
        var playerPowerup = player.GetComponent<PlayerPowerup>();

        //Increase player bounciness
        collider.material.bounciness = 1.0f;
        //Display visual change
        playerPowerup.PlayPowerupAnimation();
        //Wait a few seconds
        yield return new WaitForSeconds(powerupDuration);
        //Reset player bounciness
        collider.material.bounciness = initialBounciness;
        //Remove visual change
        playerPowerup.StopPowerupAnimation();
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        bool otherIsPlayer = other.gameObject.name == "Player";
        if (otherIsPlayer)
        {
            var playerPowerup = other.GetComponent<PlayerPowerup>();
            playerPowerup.ApplyPowerup(PowerUpEffect(player: other.gameObject));
            GameObject.Destroy(this.gameObject);
        }
    }
}
