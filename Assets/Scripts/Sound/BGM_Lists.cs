using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BGM", menuName = "Sound Object/SoundData")]
public class BGM_Lists : ScriptableObject
{
    // 0 = Walking                     
    // 1 = Bouble Gum                  
    // 2 = FUNNY                       
    // 3 = MY MISTAKE                  
    // 4 = Reflected-light             
    // 5 = Documentary                 
    // 6 = Game                        
    // 7 = JoEnNim                     
    // 8 = Waltz for child             
    // 9 = HOW ARE YOU                 
    public List<AudioClip> bgm_Clips;
}
