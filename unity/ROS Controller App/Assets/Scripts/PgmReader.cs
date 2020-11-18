using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PGM
{
    public class PgmReader : MonoBehaviour
    {
        public Image imageToUpdate;
        
        private void Start()
        {
            string InputFileName = "map.pgm"; //args[0]

            PGM picture = new PGM(InputFileName);
            var pgmInfo = picture.PrintPGMInfo();

           var mapByteArray = picture.GetPgmBytes();
           var mapColorArray = new Color[mapByteArray.Length];

           Texture2D texture = new Texture2D(int.Parse(pgmInfo[3]), int.Parse(pgmInfo[4]));
           
           for(var i = 0; i < mapByteArray.Length; i++)
           {
               var color = new Color((float)mapByteArray[i]/255, (float)mapByteArray[i]/255, (float)mapByteArray[i]/255 );
               mapColorArray[i] = color;
           }

           texture.SetPixels(mapColorArray);
           texture.Apply();

           GetComponent<Renderer>().material.mainTexture = texture;
           
           var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
       
           if (sprite != null)
           {
               imageToUpdate.sprite = sprite;
           }
        }
    }
}