using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTKv2.Common
{
    static class View
    {
        static public int Width =800;
        static public int Height = 600;
        static public Matrix4 view= Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);
        static public Matrix4 projection= Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Width / (float)Height, 0.1f, 100.0f);
        static public Matrix4 orthographic = Matrix4.CreateOrthographic(4*1f, 4*((float)Height / (float)Width), 0.1f, 100.0f);
        static public bool perspective = true;

        public static  Matrix4 getPerspective()
        {
            if (perspective) 
                return projection;
            else 
                return orthographic;
        }
        public static void togglePerspective()
        {
            if (perspective)
                perspective = false;
            else
                perspective = true;
        }
    }
}
