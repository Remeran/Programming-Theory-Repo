using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// INHERITANCE
public class Land : Animal
{
    float boundry = 70f;
    void Awake()
    {
        animalName = "Deer";
        animalAnimator = GetComponent<Animator>();
        description = animalName + " has the Land component, which inherits from the Animal class. It gets its base movement (Forward, backward, and rotation) from the Animal class and has no added functionality. It's movement is constrained via overriden abstract method called ConstrainMovement() in the Animal Class. (Every animal has different constraints)";
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Selection")
        {
            // ABSTRACTION
            Rotate();
        }

        if(SceneManager.GetActiveScene().name == "Main")
        {
            Move();
        }
    }

    // POLYMORPHISM
    protected override void ConstrainMovement()
    {
        if (transform.position.x < -boundry) 
        {
            transform.position = new Vector3(-boundry, transform.position.y, transform.position.z);
        }
        if(transform.position.x > boundry) 
        {
            transform.position = new Vector3(boundry, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -boundry)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -boundry);
        }
        if(transform.position.z > boundry)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundry);
        }
    }

}
