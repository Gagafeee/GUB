using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace DG
{
    public class rotate : MonoBehaviour
    {

        public float vel = 1;

        // Update is called once per frame
        //private void Start()
        //{
        //    if (SceneManager.GetActiveScene().name == "MainMenu")
        //    {
        //        transform.position = new Vector3(-891, 749, 0);
        //        transform.localScale = new Vector3(58, 58, 235);
        //    }
        //    if (SceneManager.GetActiveScene().name != "MainMenu")
        //    {
        //        transform.position = new Vector3(-905, 673, 0);
        //        transform.localScale = new Vector3(42, 42, 167);
        //    }
        //}

        void Update()
        {
            transform.Rotate(Vector3.forward * vel * Time.deltaTime);
        }
    }
}