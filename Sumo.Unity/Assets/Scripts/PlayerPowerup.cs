using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    [SerializeField]
    private GameObject powerupActiveDisplay;
    private Animator animator;

    public bool IsPowerupActive = false;

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
}
