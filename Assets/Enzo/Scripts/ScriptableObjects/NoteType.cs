using UnityEngine;

namespace Enzo.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NoteType")]
    public class NoteType : ScriptableObject
    {
        public int index;

        public Vector3 direction;
        public void Movement(Transform transform, float speed)
        {
            if (direction != Vector3.zero)
                transform.Translate(direction * Time.deltaTime * speed);
            else if (transform.localScale.x > 0f)
            {
                transform.localScale -= new Vector3(Time.deltaTime * speed, Time.deltaTime * speed, Time.deltaTime * speed);
            }
        }
    }
}