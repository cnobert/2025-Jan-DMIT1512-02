using UnityEngine;

public class Coin : MonoBehaviour
{
    private SoundHub _soundHub;
    void Awake()
    {
        _soundHub = GameObject.Find("SoundHub").GetComponent<SoundHub>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        //if we play sound file here, it destroys itself before we can hear anything
        _soundHub.PlayCoinSound();
        Destroy(this.gameObject);
    }
}
