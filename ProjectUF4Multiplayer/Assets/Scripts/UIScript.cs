using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private Button btnStartConnection;
    [SerializeField]
    private GameObject IpField;
    private TMP_InputField inputIp;
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    private String ipString;
    public void Awake()
    {

        if (!ConnectionManagment.getInstance().host)
        {
            textMeshProUGUI.text = "Put the Ip Here: ";
        }
        else
        {
            setIp();
            NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address = ipString;
        }
        inputIp = IpField.GetComponent<TMP_InputField>();
        btnStartConnection.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address = inputIp.text;
            NetworkManager.Singleton.StartClient();
            btnStartConnection.gameObject.SetActive(false);
            IpField.SetActive(false);
            textMeshProUGUI.gameObject.SetActive(false);
        });
    }
    public void setIp()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach(var ip in host.AddressList) { 
            if(ip.AddressFamily == AddressFamily.InterNetwork)
            {
                textMeshProUGUI.text = "Waiting for the other player... Your Ip is " + ip.ToString();
                this.ipString = ip.ToString();
            }
        }

    }
    void Start()
    {
        if (!ConnectionManagment.getInstance().host)
        {

            btnStartConnection.gameObject.SetActive(true);
            IpField.SetActive(true);
        }
        else
        {
            btnStartConnection.gameObject.SetActive(false);
            IpField.SetActive(false);
            NetworkManager.Singleton.StartHost();
        }
    }
}
public class ConnectionManagment
{
    public bool host;
    private static ConnectionManagment Singleton;
    public static ConnectionManagment getInstance()
    {
        if(Singleton == null)
        {
            Singleton = new ConnectionManagment();
        }
        return Singleton;   
    }
}