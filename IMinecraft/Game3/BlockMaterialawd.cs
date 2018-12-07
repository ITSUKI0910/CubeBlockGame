using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class BlockMaterialawd
    {
        protected string[] texture;
        protected BlockMaterialawd(string Front, string Right, string Back, string Left, string Up, string Down)
        {
            texture = new string[6] { Front, Right, Back, Left, Up, Down };
        }
        public string[] Texture(bool[] textureNumber)
        {
            int textureNumberLength = textureNumber.Length;
            string[] textureName = new string[textureNumberLength * 2];
            int d = 0;
            for (int i = 0; i < textureNumberLength; i++)
            {
                if (textureNumber[i])
                {
                    textureName[d] = texture[i];
                    d++;
                    textureName[d] = texture[i];
                    d++;
                }
            }
            return textureName;
        }
    }
}
