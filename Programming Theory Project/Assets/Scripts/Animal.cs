using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Animal : MonoBehaviour
{
    protected string animalName;
    // ENCAPSULATION
    public string description { get; protected set; }
    private float rotationSpeed = 50f;
    protected float speed = 20f;
    protected Animator animalAnimator;

    protected virtual void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        animalAnimator.SetFloat("Speed_f", verticalInput);

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * horizontalInput);
        ConstrainMovement();
    }

    protected abstract void ConstrainMovement();

    protected void Rotate()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
