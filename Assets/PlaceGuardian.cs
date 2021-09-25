using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceGuardian : MonoBehaviour
{
    public GameObject guardianPrefab;
    private GameObject guardian;
    private GameManagerBehavior gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }

    private bool CanPlaceGuardian()
    {
        return gameManager.Turret > 0 && guardian == null;
    }

    void OnMouseUp()
    {
        if (CanPlaceGuardian())
        {
            guardian = (GameObject)Instantiate(guardianPrefab, transform.position, Quaternion.identity);

            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            gameManager.Turret -= 1;
        }
    }
}
