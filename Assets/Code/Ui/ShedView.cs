using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Ui
{
    class ShedView: MonoBehaviour
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
