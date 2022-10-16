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
        //Increase player bounciness
        collider.material.bounciness = 1.0f;
        //Display visual change
        //Wait a few seconds
        yield return new WaitForSeconds(powerupDuration);
        //Reset player bounciness
        collider.material.bounciness = initialBounciness;
        Debug.Log("Bounciness reset");
        //Remove visual change
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
