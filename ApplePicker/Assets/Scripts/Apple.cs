using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Apple : MonoBehaviour
{
    
    [Header("Set in Inspector")]
    public static float bottomY = -20f;
    private Shake shake;

    private void Awake()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            // Get a reference to the ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Call the public AppleDestroyed() method of apScript
            apScript.AppleDestroyed();
            FindObjectOfType<AudioManager>().Play("Explosion");
            shake.CamShake();
            if (apScript.heartList.Count == 0)
            {
                SceneManager.LoadScene("Game_Over");
            }
        }
    }
}
