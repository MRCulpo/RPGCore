using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class MovementsManager : MonoBehaviour
{
    public Rigidbody2D rigibody { set; get; }

	void Start()
	{
		this.rigibody = GetComponent<Rigidbody2D>();
	}

	public void move( Vector2 moviment )
	{
		rigibody.velocity = new Vector2(moviment.x * Time.deltaTime, moviment.y * Time.deltaTime);
	}

	public void stop()
	{
		rigibody.velocity = Vector2.zero;
	}
}
