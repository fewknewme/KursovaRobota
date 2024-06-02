using UnityEngine;

public class CameraShaking : MonoBehaviour
{
    private Animator anim;
    private PlayerAnims PlayerAnims;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerAnims = GameObject.FindObjectOfType<PlayerAnims>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = PlayerAnims.isRunning;
        bool isWalking = PlayerAnims.isWalking;

        if (isWalking || isRunning)
        {
            anim.speed = 0.5f;
            if(isRunning)
            {
                anim.speed = 1f;
            }
        }

        else
        {
            anim.speed = 0f;
        }
    }
}
