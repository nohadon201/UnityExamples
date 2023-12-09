using OdinSerializer;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class controllerScri : MonoBehaviour
{
    public ScriptableObjectSerializarExemple exemple;
    public GameEventExample eventExample;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            GameObject go = new GameObject();
            go.name = "EJEMPLO";
            eventExample.Raise(go);
        }else if(Input.GetKeyDown(KeyCode.S))
        {
            saveGame();
        }else if(Input.GetKeyDown(KeyCode.W))
        {
            LoadGame();
        }

    }
    public void saveGame()
    {
        byte[] serializedData = SerializationUtility.SerializeValue<ScriptableObjectSerializarExemple>(exemple, DataFormat.JSON);

        string base64 = System.Convert.ToBase64String(serializedData);
        //File.WriteAllBytes("testOdin.json", serializedData);
        File.WriteAllText("testOdin.json", base64);
    }
    public void LoadGame()
    {
        string newBase64 = File.ReadAllText("testOdin.json");
        byte[] postFile = System.Convert.FromBase64String(newBase64);
        //byte[] postFile = File.ReadAllBytes("testOdin.json");


        print(postFile);


        ScriptableObjectSerializarExemple newData = SerializationUtility.DeserializeValue<ScriptableObjectSerializarExemple>(postFile, DataFormat.JSON);
        print("Nom: "+newData.name+" Edat: "+newData.edat);
        print("Num rand: " + newData.cosa.numRandom);
    }
    public void cosa(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 v = context.ReadValue<Vector2>();   

        }
        
    }
}
