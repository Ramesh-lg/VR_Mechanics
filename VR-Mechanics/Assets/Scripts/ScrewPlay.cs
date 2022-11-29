using System.Collections;
using UnityEngine;

public class ScrewPlay : MonoBehaviour
{
    [SerializeField] private GameObject screwDriver;
    [SerializeField] private GameObject screwDriverRotate;

    [SerializeField] private Vector3 currentRotation;
    public float speed = 2;

    [SerializeField] private Animator ScrewObjects;
    private bool isCollided = false;

    public AudioSource _audioSource;
    public AudioClip successAudio, pickupAudio;

    float minRotation = -45;
    float maxRotation = 45;


    private void Start()
    {
         currentRotation = transform.localRotation.eulerAngles;

        isCollided = false;
    }
    private void Update()
    {
        /*if (isCollided && (screwDriverRotate.transform.rotation.eulerAngles.y >= 0) && (screwDriverRotate.transform.rotation.eulerAngles.y <= 180))
        {
            screwDriverRotate.transform.Rotate(currentRotation * Time.deltaTime * speed);
        }*/
        if (isCollided)
        {
            ScrewObjects.Play("Rotation");// Animation
            
        }
    }

    /// <summary>
    /// On collission the isCollided bool will be true and starts 180 degreer animation for the screwdriver
    /// </summary>

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "ScrewDriver")
        {
            Debug.Log("Collided");
            isCollided = true;
            screwDriver.SetActive(false);
            screwDriverRotate.SetActive(true);
            StartCoroutine(AudioPlay());

        }
    }

    IEnumerator AudioPlay()
    {
        Debug.Log("AudioPlaying");
        yield return new WaitForSeconds(3f);
        _audioSource.PlayOneShot(successAudio);
    }
}
