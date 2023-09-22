using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aquatic : Animal
{
    private float swimSpeed = 10f;
    void Awake()
    {
        animalName = "Squid";
        animalAnimator = GetComponent<Animator>();
        description = animalName + " has the Aquatic component, which inherits from the Animal class. It gets its base movement (Forward, backward, and rotation) from the Animal class, but get's extra functionality from the Aquatic class, which allows for swimming (Hold Space to swim up and X to swim down). It's movement is constrained via overriden abstract method called ConstrainMovement() in the Animal Class (Every animal has different constraints) .";
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Selection")
        {
            Rotate();
        }

        if (SceneManager.GetActiveScene().name == "Main")
        {
            Move();
        }
    }

    protected override void Move()
    {
        base.Move();
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * swimSpeed * Time.deltaTime);
            animalAnimator.SetFloat("Speed_f", swimSpeed);
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.Translate(Vector3.down * swimSpeed * Time.deltaTime);
            animalAnimator.SetFloat("Speed_f", swimSpeed);
        }
    }

    protected override void ConstrainMovement()
    {
        if (transform.position.y > -.8f)
        {
            transform.position = new Vector3(transform.position.x, -.8f, transform.position.z);
        }
    }
}
