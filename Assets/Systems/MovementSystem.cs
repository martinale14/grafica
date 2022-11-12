using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    
    private GameObject currentCam;
    private float angle = 0;
    private bool isJumping = false;
    private Vector3 difference;

    void Start()
    {
        currentCam = GameObject.FindGameObjectWithTag("MainCamera");
        difference = currentCam.transform.position - transform.position;
    }

    public void Move(float speed, Rigidbody rb, float jumpForce)
    {
        float translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime * 2;
        float translationY = Input.GetAxis("Vertical") * speed * Time.deltaTime * 2;

        Vector3 newPos = new(translationX, 0, translationY);

        if (Mathf.Abs(translationX) > 0.0f || Mathf.Abs(translationY) > 0.0f)
        {
            GetComponent<Animator>().SetBool("isRunning", true);
            angle = Vector3.Angle(Vector3.forward, newPos);

            if(Mathf.Abs(translationX) > 0.0f)
            {
                angle *= translationX > 0.0f ? 1 : -1;
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);
        }

        transform.rotation = Quaternion.Euler(0, angle, 0);
        transform.Translate(newPos, Space.World);

        currentCam.transform.position = transform.position + difference;

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            GetComponent<Animator>().SetBool("isJumping", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Map"))
        {
            isJumping = false;
            GetComponent<Animator>().SetBool("isJumping", isJumping);
        }
        if (collision.gameObject.CompareTag("Magma"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }

}
