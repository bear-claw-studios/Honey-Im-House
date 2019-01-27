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

    void OnTriggerEnter(Collider other) //have one of these as is, the rest active but with NO MATERIAL
    {
        if (this.transform.GetSiblingIndex() == 0)
        {
            var root = other.transform.root.gameObject;
            if (root.tag == "Guy")
            {
                var model = root.transform.GetChild(0);
                Destroy(model.gameObject);

                root.transform.GetChild(1).SetPositionAndRotation(this.transform.position, root.transform.GetChild(1).rotation * this.transform.rotation);
                root.transform.GetChild(1).gameObject.SetActive(true);
                //var newGuy = Instantiate(NewModel, root.transform, true);
                var nextSibling = transform.parent.GetChild(transform.GetSiblingIndex() + 1);
                nextSibling.gameObject.GetComponent<MeshRenderer>().enabled = true;
                Destroy(this.gameObject);
            }
        }
    }
}