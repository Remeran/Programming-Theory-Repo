using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// INHERITANCE
public class Air : Animal
{
    private float flySpeed = 10f;
    void Awake()
    {
        animalName = "Sparrow";
        animalAnimator = GetComponent<Animator>();
        description = animalName + " has the Air component, which inherits from the Animal class. It gets its base movement (Forward, backward, and rotation) from the Animal class, but get's extra functionality from the Air class, which allows for flying (Hold Space to fly up and X to fly down). It's movement is constrained via overriden abstract method called ConstrainMovement() in the Animal Class  (Every animal has different constraints).";
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Selection")
        {
            // ABSTRACTION
            Rotate();
        }

        if (SceneManager.GetActiveScene().name == "Main")
        {
            Move();
            ConstrainMovement();
        }
    }

    // POLYMORPHISM
    protected override void Move()
    {
        base.Move();
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
            animalAnimator.SetFloat("Speed_f", flySpeed);
            animalAnimator.SetBool("InAir_b", true);
        }
        if (Input.GetKey(KeyCode.X) && transform.position.y > 0)
        {
            transform.Translate(Vector3.down * flySpeed * Time.deltaTime);
            animalAnimator.SetFloat("Speed_f", flySpeed);
        }
    }
    // POLYMORPHISM
    protected override void ConstrainMovement()
    {
        if(transform.position.y < 0)
        {
            transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
            animalAnimator.SetBool("InAir_b", false);
        }
    }
}
