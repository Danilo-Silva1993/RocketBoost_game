using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{

    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;
    [SerializeField] float rotationStrength = 100f;

    Rigidbody rb_player;
    AudioSource audioSource;

    private void Start() {
        rb_player = GetComponent<Rigidbody>();  
        audioSource = GetComponent<AudioSource>(); 
    }

    private void OnEnable() {
        thrust.Enable();      
        rotation.Enable();

    }

    private void FixedUpdate() {
    
        processedthrust();
        ProcessRotation();
        
        
    }

    // the thrust of the rocket
   private  void processedthrust(){
        if (thrust.IsPressed()){
           
            rb_player.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
            if(!audioSource.isPlaying){
            audioSource.Play();
            }
        }else {
            audioSource.Stop();
        
        }
    }

    //process to rotate
     private  void ProcessRotation(){
        float rotation_input = rotation.ReadValue<float>();
        //Debug.Log(rotation_input);

        if(rotation_input < 0){
           Applyrotation(rotationStrength);
        }
        else if(rotation_input > 0 ){
            Applyrotation(-rotationStrength);
        }
        
    }

    //apply to rotate
    private void Applyrotation(float rationvalue){

            rb_player.freezeRotation = true;
            transform.Rotate(Vector3.forward* rationvalue * Time.fixedDeltaTime);
            rb_player.freezeRotation = false;
    }
}


