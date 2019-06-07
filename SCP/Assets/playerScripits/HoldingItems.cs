using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]

public class HoldingItems : MonoBehaviour,IIntractable
{
   public bool isHolding;
    public Rigidbody rigidBody;
    public Transform hands;
     private static PlayerLook player;
    private PlayerLook look;
    [Space]
    private float rotSpeed = 20;
    void Start()
    {
        player = FindObjectOfType<PlayerLook>();
        rigidBody = GetComponent<Rigidbody>();
        look = FindObjectOfType<PlayerLook>();

    }
    public virtual void Update()
    {
       if(isHolding == true && GameM.playerMoving == true && Input.GetButtonDown("Fire2"))
        {
            Time.timeScale = 0;
            PauseMenuM.IsPaused = true;
            GameM.playerMoving = false;
            look.redacil.SetActive(false);
        }
        if (isHolding == true && GameM.playerMoving == false && Input.GetButtonUp("Fire2"))
        {
            Time.timeScale = 1;
            PauseMenuM.IsPaused = false;
            GameM.playerMoving = true;
            look.redacil.SetActive(true);

        }
        if (isHolding == true && GameM.playerMoving == true)
        {
            this.transform.position = hands.position;
            rigidBody.velocity = Vector3.zero;

        }
      if(GameM.playerMoving == false && isHolding == true)
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed;
            float rotY = Input.GetAxis("Mouse Y")* rotSpeed;
            transform.Rotate(Vector3.up, -rotX, Space.World);
            transform.Rotate(Vector3.right, rotY, Space.World);

        }
    }
    public virtual void  Use()
    {
     
    }
    public virtual void PickUp(Transform PlayerHands)
    {
         hands = PlayerHands;
         rigidBody.useGravity = false;
        rigidBody.isKinematic = true;
         rigidBody.velocity = Vector3.zero;
         this.transform.position = PlayerHands.position;
        this.transform.parent = PlayerHands;
        isHolding = true;
    }
    public virtual void Drop()
    {
        rigidBody.isKinematic = false;
        rigidBody.useGravity = true;
         rigidBody.AddForce(player.PlayerCam.transform.forward*player.throwForace);
         this.transform.parent = null;
        isHolding = false;

    }
     
}
