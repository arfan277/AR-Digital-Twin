using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class arm_controller : MonoBehaviour
{

    // baseSlider, armSlider 
    public Slider part1_slider;
    public Slider part2_slider;
    public Slider part3_slider;
    public Slider part4_slider;
    public Slider part5_slider;
    public Slider part6_slider;
    public Slider part7_slider;

    // slider value for base platform that goes from -1 to 1 
    private float part1_sliderValue = 0.0f;
    private float part2_sliderValue = 0.0f;
    private float part3_sliderValue = 0.0f;
    private float part4_sliderValue = 0.0f;
    private float part5_sliderValue = 0.0f;
    private float part6_sliderValue = 0.0f;
    private float part7_sliderValue = 0.0f;

    // slider value for upper arm that goes from -1 to 1 

    // plug in the appropriate robot parts into the inspector 
    // robotBase, upperArm
    public Transform part1;
    public Transform part2;
    public Transform part3;
    public Transform part4;
    public Transform part5;
    public Transform part6;
    public Transform part7;

    // adjust in the inspector for the speed of each part's rotation 
    // baseTurnRate, upperArmTurnRate 
    public float part1_TurnRate = 1.0f;
    public float part2_TurnRate = 1.0f;
    public float part3_TurnRate = 1.0f;
    public float part4_TurnRate = 1.0f;
    public float part5_TurnRate = 1.0f;
    public float part6_TurnRate = 1.0f;
    public float part7_TurnRate = 1.0f;

    // part1 max and min 
    private float part1_ZRot = 0.0f;
    public float part1_ZRotMin = -170.0f;
    public float part1_ZRotMax = 170.0f;

    // part2 max and min
    private float part2_YRot = 0.0f;
    public float part2_YRotMin = -120.0f;
    public float part2_YRotMax = 120.0f; 

    // part3 max and min 
    private float part3_ZRot = 0.0f;
    public float part3_ZRotMin = -170.0f;
    public float part3_ZRotMax = 170.0f;

    // part4 max and min 
    private float part4_YRot = 0.0f;
    public float part4_YRotMin = -120.0f;
    public float part4_YRotMax = 120.0f; 

    // part5 max and min 
    private float part5_ZRot = 0.0f;
    public float part5_ZRotMin = -170.0f;
    public float part5_ZRotMax = 170.0f;

    // part6 max and min 
    private float part6_YRot = 0.0f;
    public float part6_YRotMin = -120.0f;
    public float part6_YRotMax = 120.0f; 

    // part7 max and min 
    private float part7_ZRot = 0.0f;
    public float part7_ZRotMin = -175.0f;
    public float part7_ZRotMax = 175.0f;

    Vector3 part1_origin, part2_origin, part3_origin, part4_origin, part5_origin, part6_origin, part7_origin; 




    
    // Start is called before the first frame update
    void Start()
    {
        // Set default values to that we can bring our UI sliders into negative values 
        part1_slider.minValue = -1;
        part1_slider.maxValue = 1; 

        part2_slider.minValue = -1;
        part2_slider.maxValue = 1; 

        part3_slider.minValue = -1;
        part3_slider.maxValue = 1; 

        part4_slider.minValue = -1;
        part4_slider.maxValue = 1; 

        part5_slider.minValue = -1;
        part5_slider.maxValue = 1; 

        part6_slider.minValue = -1;
        part6_slider.maxValue = 1; 

        part7_slider.minValue = -1;
        part7_slider.maxValue = 1; 

        //Original Position

        part1_origin = new Vector3(part1.transform.position.x, part1.transform.position.y, part1.transform.position.z);
        part2_origin = new Vector3(part2.transform.position.x, part2.transform.position.y, part2.transform.position.z);
        part3_origin = new Vector3(part3.transform.position.x, part3.transform.position.y, part3.transform.position.z);
        part4_origin = new Vector3(part4.transform.position.x, part4.transform.position.y, part4.transform.position.z);
        part5_origin = new Vector3(part5.transform.position.x, part5.transform.position.y, part5.transform.position.z);
        part6_origin = new Vector3(part6.transform.position.x, part6.transform.position.y, part6.transform.position.z);
        part7_origin = new Vector3(part7.transform.position.x, part7.transform.position.y, part7.transform.position.z);
        // part1_origin = part1.transform.position;
        // part2_origin = part2.transform.position;
        // part3_origin = part3.transform.position;
        // part4_origin = part4.transform.position;
        // part5_origin = part5.transform.position;
        // part6_origin = part6.transform.position;
        // part7_origin = part7.transform.position;
 
        
    }


    void CheckInput()
    {
        part1_sliderValue = part1_slider.value;
        part2_sliderValue = part2_slider.value;
        part3_sliderValue = part3_slider.value;
        part4_sliderValue = part4_slider.value;
        part5_sliderValue = part5_slider.value;
        part6_sliderValue = part6_slider.value;
        part7_sliderValue = part7_slider.value;

    }

    void ProcessMovement()
    {
        // rotating our base of the robot her around the Y axis and multiplying
        // the rotation by the slider's value and the turn rate for the base

        // Rotate part 1
        part1_ZRot += part1_sliderValue * part1_TurnRate;
        part1_ZRot = Mathf.Clamp(part1_ZRot, part1_ZRotMin, part1_ZRotMax);
        part1.localEulerAngles = new Vector3(part1.localEulerAngles.x, part1.localEulerAngles.y, part1_ZRot); 

        // rotating our upper arm of the robot here around the X axis and multiplying
        // the rotation by the slider's value and the turn rate for the upper arm 
        part2_YRot += part2_sliderValue * part2_TurnRate;
        part2_YRot = Mathf.Clamp(part2_YRot, part2_YRotMin, part2_YRotMax);
        part2.localEulerAngles = new Vector3(part2.localEulerAngles.x, part2_YRot, part2.localEulerAngles.z);

        part3_ZRot += part3_sliderValue * part3_TurnRate;
        part3_ZRot = Mathf.Clamp(part3_ZRot, part3_ZRotMin, part3_ZRotMax);
        part3.localEulerAngles = new Vector3(part3.localEulerAngles.x, part3.localEulerAngles.y, part3_ZRot); 

        part4_YRot += part4_sliderValue * part4_TurnRate;
        part4_YRot = Mathf.Clamp(part4_YRot, part4_YRotMin, part4_YRotMax);
        part4.localEulerAngles = new Vector3(part4.localEulerAngles.x, part4_YRot, part4.localEulerAngles.z);

        part5_ZRot += part5_sliderValue * part5_TurnRate;
        part5_ZRot = Mathf.Clamp(part5_ZRot, part5_ZRotMin, part5_ZRotMax);
        part5.localEulerAngles = new Vector3(part5.localEulerAngles.x, part5.localEulerAngles.y, part5_ZRot); 

        part6_YRot += part6_sliderValue * part6_TurnRate;
        part6_YRot = Mathf.Clamp(part6_YRot, part6_YRotMin, part6_YRotMax);
        part6.localEulerAngles = new Vector3(part6.localEulerAngles.x, part6_YRot, part6.localEulerAngles.z);

        part7_ZRot += part7_sliderValue * part7_TurnRate;
        part7_ZRot = Mathf.Clamp(part7_ZRot, part7_ZRotMin, part7_ZRotMax);
        part7.localEulerAngles = new Vector3(part7.localEulerAngles.x, part7.localEulerAngles.y, part7_ZRot); 
    }

    public void ResetSliders()
    {
        // resets the sliders back to 0 when you lift up on the mouse click down (snapping effect)
        part1_sliderValue = 0.0f;
        part1_slider.value = 0.0f;
        
        part2_sliderValue = 0.0f;
        part2_slider.value = 0.0f;

        part3_sliderValue = 0.0f;
        part3_slider.value = 0.0f;

        part4_sliderValue = 0.0f;
        part4_slider.value = 0.0f;

        part5_sliderValue = 0.0f;
        part5_slider.value = 0.0f;

        part6_sliderValue = 0.0f;
        part6_slider.value = 0.0f;

        part7_sliderValue = 0.0f;
        part7_slider.value = 0.0f;
   

    }

    // Original PositiionButton
    public void origin_position()
    {
        part1.localEulerAngles = part1_origin;
        part2.localEulerAngles = part2_origin;
        part3.localEulerAngles = part3_origin;
        part4.localEulerAngles = part4_origin;
        part5.localEulerAngles = part5_origin;
        part6.localEulerAngles = part6_origin;
        part7.localEulerAngles = part7_origin;
        // part1.transform.position = part1_origin;
        // part2.transform.position = part2_origin;
        // part3.transform.position = part3_origin;
        // part4.transform.position = part4_origin;
        // part5.transform.position = part5_origin;
        // part6.transform.position = part6_origin;
        // part7.transform.position = part7_origin;

        Debug.Log("PART 1" + part1_origin); 
    }

    void Update()
    {
        CheckInput();
        ProcessMovement();
    }
}
