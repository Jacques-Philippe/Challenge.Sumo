using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    [SerializeField]
    private GameObject powerupActiveDisplay;
    private Animator animator;

    public bool IsPowerupActive = false;

    private float powerupForce = 100;

    private void Awake()
    {
        this.animator = this.GetComponent<Animator>();
    }

    public void PlayPowerupAnimation()
    {
        this.IsPowerupActive = true;
        this.powerupActiveDisplay.SetActive(true);
        animator.SetBool("isActive_b", true);
    }

    public void StopPowerupAnimation()
    {
        this.IsPowerupActive = false;
        animator.SetBool("isActive_b", false);
        this.powerupActiveDisplay.SetActive(false);
    }

    public void ApplyPowerup(IEnumerator powerup)
    {
        StartCoroutine(powerup);
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool otherIsEnemy = collision.gameObject.name.Contains("Enemy");
        if (otherIsEnemy && this.IsPowerupActive)
        {
            var playerPosition = this.transform.position;
            var enemyPosition = collision.gameObject.transform.position;
            Vector3 direction = (enemyPosition - playerPosition).normalized;
            var enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            enemyRigidbody.AddForce(direction * powerupForce, ForceMode.Impulse);
        }
    }
}
