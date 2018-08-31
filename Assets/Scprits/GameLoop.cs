using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {

    private SceneStateController controller = null;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); //切换场景不重置改物体
    }

    // Use this for initialization
    void Start()
    {
        controller = new SceneStateController();
        controller.SetState(new StartState(controller), false);
    }

    private void FixedUpdate()
    {
        if (controller != null)
            controller.StateFixedUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller != null)
            controller.StateUpdate();
    }

    private void LateUpdate()
    {
        if (controller != null)
            controller.StateLateUpdate();
    }
}
