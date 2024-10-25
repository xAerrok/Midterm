using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private float fallSpeed;
    public int points;
    private int display;    // Intermediate value for damaged crates

    [SerializeField] private GameObject digit1;
    [SerializeField] private GameObject digit2;
    [SerializeField] private Material[] digits;
    [SerializeField] public int[] minSpeed;
    [SerializeField] public int[] maxSpeed;


    void Awake()
    {
        int level = 0;
        fallSpeed = (float)Random.Range(minSpeed[level], maxSpeed[level]) / 100;
        display = points;
        UpdateDisplay();
        //Debug.LogWarning("" + fallSpeed);
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position; // new Vector3(transform.position.x, transform.position.y-fallSpeed, 0);
        pos.y -= fallSpeed;
        transform.position = pos;
    }

    void UpdateDisplay()
    {
        if (display > 9)
        {
            // set digit1 texture offset
            Renderer digimat1 = digit1.gameObject.GetComponent<Renderer>();
            digimat1.material = digits[display / 10];
        }
        else
        {
            // Disable digit1
            digit1.SetActive(false);
        }
        // set digit2 texture offset
        Renderer digimat2 = digit2.gameObject.GetComponent<Renderer>();
        digimat2.material = digits[display % 10];
    }

    static public void DAMAGE_CRATE(Crate crate, int damage)
    {
        crate.display -= damage;

        // Check for break conditions
        if (crate.display < 0)
        {
            // subtract points from player score
            
            Destroy(crate);
        }
        else if (crate.display == 0)
        {
            // add points to player score

            Destroy(crate);
        }
        // crate is not yet broken, update display to show remaining health
        else
        {
            crate.UpdateDisplay();
        }
    }
}
