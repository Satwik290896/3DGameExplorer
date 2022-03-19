using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    public GameObject Obj;
    public float speed = 5f;
    public float jumpSpeed;
    public float jumpButtonGracePeriod;
    public Animator animator;
    public MeshRenderer render_disable;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    public GameObject projectileObj;

    public static bool platform1_on = false;
    public static bool platform2_on = false;
    public static bool platform3_on = false;
    public static bool platform4_on = false;
    public static bool final_stage_on = false;

    public static bool hope_on = false;
    public static bool restart_on = false;
    public static bool red_blue_obstacle = false;
    public static bool red_blue_obstacle_2 = false;
    private bool projectile_on = false;
    public static bool hop_on_p3 = false;

    private bool time_first = true;
    private float time_count = 0;
    private float last_launch = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Obj = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(Obj.name);
        originalStepOffset = characterController.stepOffset;

        animator = GetComponent<Animator>();
        //Obj.transform.Translate(Vector3.right * Speed * Time.deltaTime);
        animator.SetBool("IsMoving",false);
        animator.SetBool("IsJump",false);
        animator.SetBool("IsBackwards",false);
        animator.SetBool("IsLeft",false);
        animator.SetBool("IsRight",false);
    }

    // Update is called once per frame
    void Update()
    {
        float translation_z = Input.GetAxis("Vertical");
        float translation_x = Input.GetAxis("Horizontal");

        Vector3 movementDirection = new Vector3(translation_x, 0, translation_z);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        if(transform.position.y < -400){
            ySpeed = Physics.gravity.y*4000;
            restart_on = true;
        }
        else{
            ySpeed = Physics.gravity.y*100;
            restart_on = false;
        }
        

        Vector3 velocity = movementDirection*magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if(movementDirection != Vector3.zero){
            if(movementDirection.z < 0){
                animator.SetBool("IsBackwards",true);
            }
            else if(movementDirection.z > 0){
                animator.SetBool("IsMoving",true);
            }
            if(movementDirection.x < 0){
                animator.SetBool("IsLeft",true);
            }
            else if(movementDirection.x > 0){
                animator.SetBool("IsRight",true);
            }
            
        }
        else{


        if(Left_Button.cha_left_on){
            animator.SetBool("IsLeft",true);
        }
        else{
            animator.SetBool("IsLeft",false);
        }
        if(Right_Button.cha_right_on){
            animator.SetBool("IsRight",true);
        }
        else{
            animator.SetBool("IsRight",false);
        }

        if(Forward_Button.cha_forward_on == true){
            animator.SetBool("IsMoving",true);
        }
        else{
            animator.SetBool("IsMoving",false);
        }

        if(Backward_Button.cha_backward_on == true){
            animator.SetBool("IsBackwards",true);
        }
        else{
            animator.SetBool("IsBackwards",false);
        }
        }

        if(time_first == true){
            time_count = Time.time+2;
        }

        if( ((platform1_on == true) && (hope_on == true) && (time_first == true)) ||
            ((time_first == false)&&(time_count >= Time.time)) ){
            //Debug.Log("YYYYEEEESSSSSSSSSSSSSSS");
            time_first = false;
            projectile_on = true;
            projectile();
            //Debug.Log("Here it is (time_count222222222):  " + time_count);
        }

        if(LeftRotate_Button.lr_on ==true){
            transform.Rotate(0, -60*Time.deltaTime, 0);
        }
        else if(RightRotate_Button.rr_on ==true){
            transform.Rotate(0, 60*Time.deltaTime, 0);
        }
    }

    void LateUpdate(){
        if(Restart_Button.restart_success == true){
            //restart_on = false;
        }
    }

    void OnTriggerEnter(Collider myCollider){
        if(myCollider.tag == "Red_Blue_Obstacle_2"){
            red_blue_obstacle_2 = true;
            Debug.Log("Red_Blue_Obstacle2");
        }
    }
    void OnTriggerExit(Collider myCollider){
        if(myCollider.tag == "Red_Blue_Obstacle_2"){
            red_blue_obstacle_2 = false;
            Debug.Log("Red_Blue_Obstacle2_Exit");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        Collider myCollider = collision.contacts[0].thisCollider;
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Platform1"){
            platform1_on = true;
            platform2_on = false;
            platform3_on = false;
            platform4_on = false;
            final_stage_on =false;
            hop_on_p3 = false;
        }
        else if(collision.gameObject.tag == "Platform2"){
            platform2_on = true;
            platform1_on = false;
            platform3_on = false;
            platform4_on = false;
            final_stage_on =false;
            hop_on_p3 = false;
        }
        else if(collision.gameObject.tag == "Platform3"){
            platform3_on = true;
            platform1_on = false;
            platform2_on = false;
            platform4_on = false;
            final_stage_on =false;
            
            if(hop_on_p3 == false){
                Application.LoadLevel(2);
                hop_on_p3 = true;
            }
            
        }
        else if(collision.gameObject.tag == "Platform4"){
            platform4_on = true;
            platform1_on = false;
            platform2_on = false;
            platform3_on = false;
            final_stage_on =false;
        }
        if((collision.gameObject.tag == "Hope") && (platform1_on == true) && (hope_on == false)){
            hope_on = true;
            //Destroy (collision.gameObject);
            projectileObj = collision.gameObject;
                    Vector3 vec = new Vector3(100,10,10);
                    Debug.Log("GGGGGGGGOOOOOOOTTTTTTTTTTTTTT");
            //Instantiate(projectileObj, transform.position + vec,transform.rotation);
        }
        if(collision.gameObject.tag == "Final_Stage"){
            restart_on = true;
            final_stage_on =true;
        } 
        if((collision.gameObject.tag == "Red_Blue_Obstacle") || (myCollider.tag == "Red_Blue_Obstacle")){
            Debug.Log("Collisionnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn");
            red_blue_obstacle = true;
        } 
    }
    void OnCollisionStay(Collision collision){
        Collider myCollider = collision.contacts[0].thisCollider;
        if(collision.gameObject.tag == "Platform2" || collision.gameObject.tag == "Platform3" || collision.gameObject.tag == "Platform4"){
            hope_on = false;
            //Debug.Log(collision.gameObject.name);
        }
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Hope"){
            //Vector3 vec = new Vector3(100,10,10);
            //Destroy (collision.gameObject);
            
            //projectileObj = collision.gameObject;
            //Instantiate(collision.gameObject,transform.position + vec,transform.rotation);
            //Debug.Log(collision.gameObject.name);
            //transform.SetParent(collision.transform);
            //transform.parent = collision.transform;
 
        }
        if((collision.gameObject.tag == "Red_Blue_Obstacle") || (myCollider.tag == "Red_Blue_Obstacle")){
            //Debug.Log("Collision22");
            red_blue_obstacle = true;
            Debug.Log("Red_Blue_Obstacle");
        } 
        else{
            red_blue_obstacle = false;
        }
    }
 
    void OnCollisionExit(Collision collision){
        Collider myCollider = collision.contacts[0].thisCollider;
        if(collision.gameObject.tag == "Platform1"){
            //Debug.Log(collision.gameObject.name);
            //transform.SetParent(null);
             //transform.parent = null;
             platform1_on = false;
             hope_on = false;
             Debug.Log("HOPE ON is FALSE.........!");
             
        }
        if((collision.gameObject.tag == "Red_Blue_Obstacle") || (myCollider.tag == "Red_Blue_Obstacle")){
            red_blue_obstacle = false;
        }
    }

    private void projectile(){
        Vector3 vec = new Vector3(0,10,40);

            //Debug.Log("Here it is:  " + Time.time);
        if(hope_on == true && Projectile_Launch.pro_launch_on == true && (Time.time - last_launch > 0.5)){
            Instantiate(projectileObj, transform.position+vec ,transform.rotation);
            last_launch = Time.time;

        }
        //Debug.Log("Hello!");
        time_count = Time.time+2;
        //Debug.Log("Here it is (time_count):  " + time_count);
    }  
}
