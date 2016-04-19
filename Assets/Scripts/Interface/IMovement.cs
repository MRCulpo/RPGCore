using UnityEngine;
using System.Collections;

interface IMovement
{
     void move();
     void jump();
     void down();
     void stop();
     void move(float _velocity);
     void jump(float _velocity);
     void down(float _velocity);
     void move(Vector2 _velocity);
     void jump(Vector2 _velocity);
     void down(Vector2 _velocity);
}
