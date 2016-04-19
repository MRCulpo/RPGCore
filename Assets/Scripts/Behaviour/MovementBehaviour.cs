using UnityEngine;
using System.Collections;

public class MovementBehaviour : MonoBehaviour
{
    public Rigidbody2D rigidbody2D{set; get;}

    public float velocityJump;
    public float velocityHorizontal;
    public float velocityVertical;

    void Awake()
    {
        this.rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public virtual void stop()
    {
        this.rigidbody2D.velocity =  new Vector2(0, this.rigidbody2D.velocity.y);
    }

    public virtual void jump(float _velocity)
    {
        this.rigidbody2D.AddForce(new Vector2(0f, _velocity));
    }

    public virtual void jump()
    {
        this.rigidbody2D.AddForce(new Vector2(0f, this.velocityJump));
    }

    public virtual void move(Vector2 _velocity)
    {
        this.rigidbody2D.velocity = _velocity;
    }
}
