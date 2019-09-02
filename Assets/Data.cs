using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static string[] names;
    public static string[] tastes;
    public static Color[] colors;

    private void Awake()
    {
        names = new string[]
        {
            "Julio Jaramistery",
            "Armando y Desarmando",
            "Albaro Uribe Viriviri",
            "Gustavo Potter",
            "Pablo Emilio Escoba Trapera",
            "Metallicarlos",
            "Iron Manuel",
            "Judas Pablo",
            "Pink Flor",
            "MegaDiego",
            "Linkin Pacho",
            "Guns And Rodri",
            "Green Dayana",
            "JorgeSlayer",
            "Juan Sabath",
            "MotorJaime",
            "AC/D César",
            "System of a Doris",
            "Sepultulio",
            "Mercyful Fabio"
        };
        tastes = new string[]
        {
            "tumores y coágulos de salgre",
            "cerebro y corazón",
            "páncreas y riñones (sin cálculos)",
            "chunchurria humana",
            "pompas"
        };
        colors = new Color[]
        {
            Color.cyan,
            Color.magenta,
            Color.green
        };
    }
    
}
