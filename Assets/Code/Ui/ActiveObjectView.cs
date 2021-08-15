using System;
using UnityEngine;

namespace Assets.Code.Ui
{
    public class ActiveObjectView: MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D collision)
        {
            OnEnter?.Invoke(collision.gameObject);
        }

        public void Move(float value)
        {
            transform.position -= Vector3.right * value;
        }

        public Action<GameObject> OnEnter;
    }
}
