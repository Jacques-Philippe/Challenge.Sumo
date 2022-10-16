using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    [SerializeField]
    private GameObject powerupActiveDisplay;
    private Animator animator;

    private void Awake()
    {
        this.animator = this.GetComponent<Animator>();
    }

    public void PlayPowerupAnimation()
    {
        this.powerupActiveDisplay.SetActive(true);
        animator.SetBool("isActive_b", true);
    }

    public void StopPowerupAnimation()
    {
        animator.SetBool("isActive_b", false);
        this.powerupActiveDisplay.SetActive(false);
    }

    public void ApplyPowerup(IEnumerator powerup)
    {
        StartCoroutine(powerup);
    }
}
