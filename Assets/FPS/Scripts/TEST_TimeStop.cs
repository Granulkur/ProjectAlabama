using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Timers;
using UnityEngine;

public class TEST_TimeStop : MonoBehaviour
{
    bool isRealTime = false;
    float ResumeTimer;

    PlayerWeaponsManager m_WeaponsManager;
    Vector3 oldPosition;
    bool m_WasPointingAtEnemy;

    // Start is called before the first frame update
    void Start()
    {
        m_WeaponsManager = GameObject.FindObjectOfType<PlayerWeaponsManager>();
        oldPosition = transform.position;
    }

    private void Update()
    {
        /*if (!m_WasPointingAtEnemy && m_WeaponsManager.isPointingAtEnemy)
         {
             Pause();
         }
         else if (m_WasPointingAtEnemy && !m_WeaponsManager.isPointingAtEnemy)
         {
             Resume();
         }*/

        //WASD key
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.D))
        {
            //Pause();
            Resume(1f);
        }

        //Aiming or shooting
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Resume(5f);
        }

        //Check real-time
        if(ResumeTimer <= 0)
        {
            ResumeTimer = 0;
            isRealTime = false;
            Pause();
        }
        else
        {
            ResumeTimer -= Time.deltaTime;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Debug.Log("Resume");
        isRealTime = true;
    }

    public void Resume(float time)
    {
        ResumeTimer = time;
        Resume();
    }

    private void Pause()
    {
        Time.timeScale = 0.0f;
        isRealTime = false;
    }
}
