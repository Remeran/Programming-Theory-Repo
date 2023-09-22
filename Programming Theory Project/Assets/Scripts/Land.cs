using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Land : Animal
{
    void Awake()
    {
        animalName = gameObject.name;
        animalAnimator = GetComponent<Animator>();
        description = animalName + " has the Land component, which inherits from the Animal class. It gets its base movement (Forward, backward, and rotation) from the Animal class and has no added functionality. It's movement is constrained via overriden abstract method called ConstrainMovement() in the Animal Class. (Every animal has different constraints)";
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Selection")
        {
            Rotate();
        }

        if(SceneManager.GetActiveScene().name == "Main")
        {
            Move();
        }
    }

    protected override void ConstrainMovement()
    {
        
    }

}
