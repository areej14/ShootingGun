using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootGun : MonoBehaviour
{
    //variable to count the no of bullets
    int counter = 0;
    public ParticleSystem Flash;
    public AudioSource ShootSound;
    public Vector3 startPosition;
    //Gameobjects
    public GameObject Gun;
    public GameObject Magazine;
    public GameObject shell;
    //Text
    public Text value;
    string textVal;
    Animator anim;
   

    public void Start()
    {
        anim = Magazine.GetComponent<Animator>();
        anim.enabled = false;
    }
   // Gun shoot function works  when button is clicked
    public void Shoot()
    {
        //check bullet limit
        if (counter < 10)
        {
            ShootSound.Play();
            Flash.Play();
            //enable mesh
            shell.GetComponent<Renderer>().enabled = true;
            //shell
            Instantiate(shell, new Vector3((float)1.10029998, (float)0.140200004, (float)-0.689999998), Quaternion.identity);
            counter++;
            //text display
            textVal = "Shots left: "+counter + "/10";
            value.text = textVal;
            //position function
            changePos();
            //animation
            Invoke("changeAnim", 4f);
        }
        
           
      
    }
    // gun will move forward
        public void changePos()
        {
        
            startPosition = new Vector3((float)-0.689999974, (float)-0.0599999987, (float)-0.230000004);
            Gun.transform.position = startPosition;
            Invoke("orgPosition", 0.1f);

        }
    // set gun back to its original position
        public void orgPosition()
    {
           startPosition = new Vector3((float)-0.589999974, (float)-0.0599999987, (float)-0.230000004);
           Gun.transform.position = startPosition;
    }
    public void changeAnim()
    {
        if (counter == 10)
        {
           
            anim.enabled = true;
            anim.Play("MagAnim");
            counter = 0;
            // Magazine reload text
            textVal = "Reload Magazine :D";
            value.text = textVal;

        }

    }

}
        
