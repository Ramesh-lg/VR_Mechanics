using UnityEngine;

public class ScrewPlay : MonoBehaviour
{
    [SerializeField]
    private GameObject screwDriver;
    [SerializeField]
    private GameObject screwDriverRotate;

    [SerializeField]
    private Animator ScrewObjects;
    private bool isCollided = false;

    //public float speed = 3F;

    private void Start()
    {
        isCollided = false;
    }
    private void Update()
    {
        if (isCollided)
        {
            ScrewObjects.Play("Rotation"); 

        }
    }

    /// <summary>
    /// On collission the isCollided bool will be true and starts 180 degreer animation for the screwdriver
    /// </summary>
    /// <param name="collider"></param>

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "ScrewDriver")
        {
            Debug.Log("Collided");
            isCollided = true;
            screwDriver.SetActive(false);
            screwDriverRotate.SetActive(true);

        }
    }
}
