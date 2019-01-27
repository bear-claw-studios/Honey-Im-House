using UnityEngine;

public class Trigger : MonoBehaviour
{
    bool triggersOn = true;

    void Start()
    {
    }

    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (this.transform.GetSiblingIndex() == 0)
        {
            triggersOn = false;
            var root = other.transform.root.gameObject;
            if (root.tag == "Guy")
            {
                var model = root.transform.GetChild(0);
                if (model.transform.GetSiblingIndex() != model.transform.parent.childCount - 1)
                {
                    Destroy(model.gameObject);
                    root.transform.GetChild(1).gameObject.SetActive(true);
                    root.transform.GetChild(1).SetPositionAndRotation(this.transform.position, root.transform.GetChild(1).rotation * this.transform.rotation);
                }

                if (transform.GetSiblingIndex() != transform.parent.childCount - 1)
                {
                    var nextSibling = transform.parent.GetChild(transform.GetSiblingIndex() + 1);
                    nextSibling.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    triggersOn = true;
                    Destroy(this.gameObject);
                }
                else
                {
                    //end the game?
                }
            }
            triggersOn = true;
        }
    }
}