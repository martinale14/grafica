using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Assets.Personajes.Astronaut.scripts
{
    public class AstronautComponent : MonoBehaviour
    {
        private AstronautEntity entity;
        private MovementSystem movementSystem;
        public Image imageUI;
        public GameObject Activate;
        public GameObject Desactivate;
        private bool plank=false;
        private bool rock=false;
        private bool sand=false;
        private bool levelUp = false;

        public GameObject ButtonA;
        public GameObject ButtonB;
        public GameObject ButtonC;


        private void Start()
        {
            entity = GetComponent<AstronautEntity>();
            movementSystem = GetComponent<MovementSystem>();
            ButtonA = GameObject.Find("ButtonA");
            ButtonB = GameObject.Find("ButtonB");
            ButtonC = GameObject.Find("ButtonC");
            ButtonA.SetActive(false);
            ButtonB.SetActive(false);
            ButtonC.SetActive(false);
        }

        void Update()
        {
            movementSystem.Move(entity.speed, entity.rb, entity.jumpForce);
            NextLevel();
        }

        private void FixedUpdate()
        {
            GravitySystem.SetGravityScale(entity.gravityScale, entity.rb);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ligth"))
            {
                Destroy(other.gameObject,1);
             
            }

            if (other.gameObject.CompareTag("Plank"))
            {
                Destroy(other.gameObject);
                entity.plankCount++;
                if (entity.plankCount <= 5)
                {
                    imageUI = GameObject.Find("inventorySlot2").GetComponent<Image>();
                    imageUI.sprite = Resources.Load<Sprite>("hud/icons/madera"+ entity.plankCount.ToString() + "_5");

                }
                if (entity.plankCount ==3)
                {
                    plank = true;
                    //GameObject.Find("RawImageRecompensa").GetComponent<RawImage>().enabled = true;
                    //GameObject.Find("RawImageRecompensa").GetComponent<VideoPlayer>().Play();
                }
            }
            if (other.gameObject.CompareTag("Rock"))
            {
                Destroy(other.gameObject);
                entity.rockCount++;
                if (entity.rockCount <= 8)
                {
                    imageUI = GameObject.Find("inventorySlot1").GetComponent<Image>();
                    imageUI.sprite = Resources.Load<Sprite>("hud/icons/piedra" + entity.rockCount.ToString() + "_8");
                }
                if (entity.rockCount == 3)
                {
                    rock = true;
                    //GameObject.Find("RawImageRecompensa").GetComponent<RawImage>().enabled = true;
                    //.Find("RawImageRecompensa").GetComponent<VideoPlayer>().Play();
                }
            }
            if (other.gameObject.CompareTag("Sand"))
            {
                Destroy(other.gameObject);
                entity.sandCount++;
                if (entity.sandCount <= 10)
                {
                    imageUI = GameObject.Find("inventorySlot3").GetComponent<Image>();
                    imageUI.sprite = Resources.Load<Sprite>("hud/icons/arena" + entity.sandCount.ToString() + "_10");
                }
                if (entity.sandCount == 3)
                {
                    sand = true;
                    //GameObject.Find("RawImageRecompensa").GetComponent<RawImage>().enabled = true;
                    //GameObject.Find("RawImageRecompensa").GetComponent<VideoPlayer>().Play();
                }
            }
            if (other.gameObject.CompareTag("rocaA"))
            {
                Destroy(other.gameObject);
                imageUI = GameObject.Find("inventorySlot1_2").GetComponent<Image>();
                imageUI.sprite = Resources.Load<Sprite>("hud/icons/rocaA_Obtenida");
                ButtonA.SetActive(true);

            }
            if (other.gameObject.CompareTag("rocaB"))
            {
                Destroy(other.gameObject);
                imageUI = GameObject.Find("inventorySlot2_2").GetComponent<Image>();
                imageUI.sprite = Resources.Load<Sprite>("hud/icons/rocaB_Obtenida");
                ButtonB.SetActive(true);
            }
            if (other.gameObject.CompareTag("rocaC"))
            {
                Destroy(other.gameObject);
                imageUI = GameObject.Find("inventorySlot3_2").GetComponent<Image>();
                imageUI.sprite = Resources.Load<Sprite>("hud/icons/rocaC_Obtenida");
                ButtonC.SetActive(true);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Meteoro"))
            {

                Destroy(other.gameObject);
                entity.life--;
                //Debug.Log(entity.life);
                imageUI = GameObject.Find("lifeBar").GetComponent<Image>();
                if (entity.life == -3)
                {
                    imageUI.sprite = Resources.Load<Sprite>("hud/yellowLife");
                }
                if (entity.life == -6)
                {
                    imageUI.sprite = Resources.Load<Sprite>("hud/redLife");
                }
                if (entity.life == -9)
                {
                    imageUI.sprite = Resources.Load<Sprite>("hud/noLife");
                    /*
                     * 
                     * Aqui va lo del GameOver
                     * 
                     */
                }
            }
            if (other.gameObject.CompareTag("Magma"))
            {

                entity.life--;
                imageUI = GameObject.Find("lifeBar").GetComponent<Image>();
                if (entity.life == -3)
                {
                    imageUI.sprite = Resources.Load<Sprite>("hud/yellowLife");
                }
                if (entity.life == -6)
                {
                    imageUI.sprite = Resources.Load<Sprite>("hud/redLife");
                }
                if (entity.life == -12)
                {
                    imageUI.sprite = Resources.Load<Sprite>("hud/noLife");
                    /*
                     * 
                     * Aqui va lo del GameOver
                     * 
                     */
                }
            }
        }
        private void NextLevel() {
            if (!levelUp) {            
            if (sand && plank && rock) {
                entity.life = 0;
                Desactivate.SetActive(false);
                levelUp = true;

            } 
            }
        
        }

    }

}
