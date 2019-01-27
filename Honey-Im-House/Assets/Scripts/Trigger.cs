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
        var root = other.transform.root.gameObject;
        if (root.tag == "Guy")
        {
            var model = root.transform.GetChild(0);
            Destroy(model.gameObject);

            root.transform.GetChild(1).SetPositionAndRotation(this.transform.position, root.transform.GetChild(1).rotation * this.transform.rotation);
            root.transform.GetChild(1).gameObject.SetActive(true);
            //var newGuy = Instantiate(NewModel, root.transform, true);
            Destroy(this.gameObject);
        }
    }
}