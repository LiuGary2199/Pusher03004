using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownIDPianoGel : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Newrove")]    public GameObject Utility;
[UnityEngine.Serialization.FormerlySerializedAs("Oldtop")] public GameObject Fringe;
[UnityEngine.Serialization.FormerlySerializedAs("Slot_Obstruction")]    public GameObject Crab_Absenteeism;
[UnityEngine.Serialization.FormerlySerializedAs("Slot_Obstruction_1")]    public GameObject Crab_Absenteeism_1;
[UnityEngine.Serialization.FormerlySerializedAs("Slot_Obstruction_2")]    public GameObject Crab_Absenteeism_2;
[UnityEngine.Serialization.FormerlySerializedAs("Slot_Bottom_1")]    public GameObject Crab_Disuse_1;
[UnityEngine.Serialization.FormerlySerializedAs("SlotTop")]    public GameObject CrabMob;
[UnityEngine.Serialization.FormerlySerializedAs("Plane")]    public GameObject Apart;
[UnityEngine.Serialization.FormerlySerializedAs("Image")]    public GameObject Honey;
[UnityEngine.Serialization.FormerlySerializedAs("Arrow")]    public GameObject Harem;
[UnityEngine.Serialization.FormerlySerializedAs("Pusher")]    public MeshRenderer Reveal;
[UnityEngine.Serialization.FormerlySerializedAs("Pusher_mat")]    public Material Reveal_Pit;
[UnityEngine.Serialization.FormerlySerializedAs("Bottom")]    public MeshRenderer Disuse;
[UnityEngine.Serialization.FormerlySerializedAs("Bottom_mat")]    public Material Disuse_Pit;
[UnityEngine.Serialization.FormerlySerializedAs("Hold")]    public MeshRenderer Tail;
[UnityEngine.Serialization.FormerlySerializedAs("Hold_mat")]   // public MeshRenderer Hold_1;
    public Material Tail_Pit;
    // public Material Hold_1_mat;

    public MeshRenderer Hold_1;
    public Material Hold_1_mat;
    public void ScantGelChimp() 
    {
        if (KettleSure.HeYield())
        {
            Utility.SetActive(true);
            Fringe.SetActive(false);
          //  Crab_Absenteeism.SetActive(false);
           // Crab_Absenteeism_1.SetActive(false);
            //Crab_Absenteeism_2.SetActive(false);
         //   CrabMob.SetActive(false);
            Apart.SetActive(false);
            Honey.SetActive(false);
          //  Crab_Disuse_1.SetActive(false);
            //  Harem.SetActive(false);
            //    Reveal.material = Reveal_Pit;
            //   Disuse.material = Disuse_Pit;
            //  Tail.material = Tail_Pit;
            Hold_1.material = Hold_1_mat;
        }
        else
        {
            Utility.SetActive(false);
            Fringe.SetActive(true);
            Crab_Absenteeism.SetActive(true);
            Crab_Absenteeism_1.SetActive(true);
            Crab_Absenteeism_2.SetActive(true);
            CrabMob.SetActive(true);
            Apart.SetActive(true);
            Honey.SetActive(true);
            Crab_Disuse_1.SetActive(true);
            Harem.SetActive(true);
        }
    }
}
