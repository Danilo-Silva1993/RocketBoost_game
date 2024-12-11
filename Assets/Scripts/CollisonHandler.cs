using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;
    // wwe get the return of the object we bump

    private void OnCollisionEnter(Collision other) {
        
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("nice");
                break;
            case "Finish":
                StartNextLevel();
                
                break;
            case "Fuel":
                Debug.Log("fuel");
                break;
            default:
                StartCrashSequence();
                
                break;
        }
    
    }
    //teleport to other sites
    void transportTo(){
            int currentScene = SceneManager.GetActiveScene().buildIndex;
           
                SceneManager.LoadScene(currentScene);
          
             
    }

    //loading next level
    void LoadNextLevel(){
        int nexttScene = SceneManager.GetActiveScene().buildIndex +1;
        
        if(nexttScene != SceneManager.sceneCountInBuildSettings){
            SceneManager.LoadScene(nexttScene);
        }else {
            nexttScene = 0;
            SceneManager.LoadScene(nexttScene);
        }
    }

    //to do add sfx and particles
    void StartCrashSequence(){
        GetComponent<Movement>().enabled = false;
        Invoke("transportTo", levelLoadDelay);
    }

    //to do add sfx and particles
    void StartNextLevel(){
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }
    
}
