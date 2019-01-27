using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject NewModel;

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
            var root = other.transform.root.gameObject;
            if (root.tag == "Guy")
            {
                var model = root.transform.GetChild(0);
                if (model.transform.GetSiblingIndex() != model.transform.parent.childCount - 1)
                {
                    Destroy(model.gameObject);
                }

                if (transform.GetSiblingIndex() != transform.parent.childCount - 1)
                {
                    root.transform.GetChild(1).gameObject.SetActive(true);
                    root.transform.GetChild(1).SetPositionAndRotation(this.transform.position, root.transform.GetChild(1).rotation * this.transform.rotation);
                    var nextSibling = transform.parent.GetChild(transform.GetSiblingIndex() + 1);
                    nextSibling.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    Destroy(this.gameObject);
                }
                else
                {
                    //end the game?
                }
            }
        }
    }
}