using UnityEngine;
using System.Collections;

public enum SIDE {LEFT, RIGHT, UP, DOWN, NONE}

public class InputPlayerController : MonoBehaviour {

	public float velocity = 50F;
    
	private SIDE side;


	private MovementsManager movementsManager;
    private GeneralBehaviour generalcontrol;

    bool test = true;

	void Start()
	{
		this.side = SIDE.NONE;
        this.generalcontrol = GetComponent<GeneralBehaviour>();
        this.generalcontrol.init();
        this.getComponentsControl();
	}

    public void getComponentsControl()
    {
        
        if (this.movementsManager != null)
        {
            this.movementsManager.stop();
            this.movementsManager.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.movementsManager.enabled = false;
        }

        this.movementsManager = generalcontrol.NPCChargeControl().GetComponent<MovementsManager>();
        this.movementsManager.enabled = true;
        this.movementsManager.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

	void Update()
	{

        if(Input.GetKeyDown(KeyCode.P))
        {
            generalcontrol.chargeClothes();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            this.getComponentsControl();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<PlayerBehaviour>().character.level.addExperience(Random.Range(100, 10500));
            }

            if (Input.GetKey(KeyCode.W))
            {
                this.side = SIDE.UP;
                this.movementsManager.move(new Vector2(0F, velocity));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.side = SIDE.DOWN;
                this.movementsManager.move(new Vector2(0F, -velocity));
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.side = SIDE.RIGHT;
                this.movementsManager.move(new Vector2(velocity, 0F));
            }
            else if (Input.GetKey(KeyCode.A))
            {
                this.side = SIDE.LEFT;
                this.movementsManager.move(new Vector2(-velocity, 0F));
            }
            else if (movementsManager.rigibody.velocity != Vector2.zero)
            {
                this.side = SIDE.NONE;
                this.movementsManager.stop();
            }
        }
	}
}
