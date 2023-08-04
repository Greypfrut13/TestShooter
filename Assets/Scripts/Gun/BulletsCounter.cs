using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bulletsInClipText;
    [SerializeField] private TextMeshProUGUI _currentBulletsCountText;

    private Gun _gun;
    private int _bulletsInClip;
    private int _currentBulletsCount;

    private void Start() 
    {
        _bulletsInClipText.text = _bulletsInClip.ToString();
        _currentBulletsCountText.text = _currentBulletsCount.ToString();
    }

    public void SetGun(Gun gun, int bulletsInClip, int currentBulletsCount)
    {
        _gun = gun;
        _bulletsInClip = bulletsInClip;
        _currentBulletsCount = currentBulletsCount;
    }

    public void UpdateCurrentBulletsText(int currentBulletsCount)
    {
        _currentBulletsCountText.text = currentBulletsCount.ToString();
    }
}
