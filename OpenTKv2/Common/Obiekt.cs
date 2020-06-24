using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace OpenTKv2.Common
{
    class Obiekt
    {
        float[] _vertices = {
    -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,0.0f, 0.0f,0.0f,
     0.5f, -0.5f, -0.5f,  1.0f, 0.0f,0.0f, 0.0f,0.0f,
     0.5f,  0.5f, -0.5f,  1.0f, 1.0f,0.0f, 0.0f,0.0f,
     0.5f,  0.5f, -0.5f,  1.0f, 1.0f,0.0f, 0.0f,0.0f,
    -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,0.0f, 0.0f,0.0f,
    -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,0.0f, 0.0f,0.0f,

    -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,0.0f, 0.0f,0.0f,
     0.5f, -0.5f,  0.5f,  1.0f, 0.0f,0.0f, 0.0f,0.0f,
     0.5f,  0.5f,  0.5f,  1.0f, 1.0f,0.0f, 0.0f,0.0f,
     0.5f,  0.5f,  0.5f,  1.0f, 1.0f,0.0f, 0.0f,0.0f,
    -0.5f,  0.5f,  0.5f,  0.0f, 1.0f,0.0f, 0.0f,0.0f,
    -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,0.0f, 0.0f,0.0f,

    -0.5f,  0.5f,  0.5f,  1.0f, 0.0f,0.0f, 0.0f,0.0f,
    -0.5f,  0.5f, -0.5f,  1.0f, 1.0f,0.0f, 0.0f,0.0f,
    -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,0.0f, 0.0f,0.0f,
    -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,0.0f, 0.0f,0.0f,
    -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,0.0f, 0.0f,0.0f,
    -0.5f,  0.5f,  0.5f,  1.0f, 0.0f,0.0f, 0.0f,0.0f,

     0.5f,  0.5f,  0.5f,  1.0f, 0.0f,0.0f, 0.0f,0.0f,
     0.5f,  0.5f, -0.5f,  1.0f, 1.0f,0.0f, 0.0f,0.0f,
     0.5f, -0.5f, -0.5f,  0.0f, 1.0f,0.0f, 0.0f,0.0f,
     0.5f, -0.5f, -0.5f,  0.0f, 1.0f,0.0f, 0.0f,0.0f,
     0.5f, -0.5f,  0.5f,  0.0f, 0.0f,0.0f, 0.0f,0.0f,
     0.5f,  0.5f,  0.5f,  1.0f, 0.0f,0.0f, 0.0f,0.0f,

    -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,0.0f, 0.0f,0.0f,
     0.5f, -0.5f, -0.5f,  1.0f, 1.0f,0.0f, 0.0f,0.0f,
     0.5f, -0.5f,  0.5f,  1.0f, 0.0f,0.0f, 0.0f,0.0f,
     0.5f, -0.5f,  0.5f,  1.0f, 0.0f,0.0f, 0.0f,0.0f,
    -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,0.0f, 0.0f,0.0f,
    -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,0.0f, 0.0f,0.0f,

    -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,0.0f, 0.0f,0.0f,
     0.5f,  0.5f, -0.5f,  1.0f, 1.0f,0.0f, 0.0f,0.0f,
     0.5f,  0.5f,  0.5f,  1.0f, 0.0f,0.0f, 0.0f,0.0f,
     0.5f,  0.5f,  0.5f,  1.0f, 0.0f,0.0f, 0.0f,0.0f,
    -0.5f,  0.5f,  0.5f,  0.0f, 0.0f,0.0f, 0.0f,0.0f,
    -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,0.0f, 0.0f,0.0f
};

        private uint[] _indices =
        {
            0, 1, 3,
            1, 2, 3
        };

        public Texture tx;
        public Texture tx2;

        float rotX = 0;
        float rotY = 0;
        float rotZ = 0;

        private int _vertexBufferObject;
        private int _vertexArrayObject;
        private int _elementBufferObject;

        public Obiekt(float[] vert,uint[] indi)
        {
            _vertices = vert;
            _indices = indi;
        }
        public Obiekt() { }
        public Obiekt(string path) { loadObiektFromObjFile(path); }


        public void Load(Shader shader)
        {
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);

            tx = new Texture("Resources/szcz.png");
            tx.Use();

            tx2 = new Texture("Resources/blood.png");
            tx2.Use(TextureUnit.Texture1);

            // Next, we must setup the samplers in the shaders to use the right textures.
            // The int we send to the uniform is which texture unit the sampler should use.
            shader.SetInt("texture0", 0);
            shader.SetInt("texture1", 1);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);

            var vertexLocation = shader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);
            
            int texCoordLocation = shader.GetAttribLocation("aTexCoord");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));

            int normCoordLocation = shader.GetAttribLocation("aNormCoord");
            GL.EnableVertexAttribArray(normCoordLocation);
            GL.VertexAttribPointer(normCoordLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 5 * sizeof(float));
        }
        public void Unload()
        {
            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteBuffer(_elementBufferObject);
            GL.DeleteVertexArray(_vertexArrayObject);
            GL.DeleteTexture(tx.Handle);
        }
        public void Render(Shader shader)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.BindVertexArray(_vertexArrayObject);
            // Note: The matrices we'll use for transformations are all 4x4.

            // We start with an identity matrix. This is just a simple matrix that doesn't move the vertices at all.
            var transform = Matrix4.Identity;

            rotY = (rotY >= 360) ? 0f : (rotY + 0.2f);
            rotX = (rotX >= 360) ? 0f : (rotX + 0.2f);

            transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotX));
            transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotY));
            transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotZ));
            transform *= Matrix4.CreateScale(0.2f);
            transform *= Matrix4.CreateTranslation(0.0f, 0.0f, 0.0f);
            var light = new Light();
            light.Color = new Vector3(1, 1, 1);
            light.Position = new Vector3(1, 1, 20);

            tx.Use();
            tx2.Use(TextureUnit.Texture1);
            shader.Use();

            // Now that the matrix is finished, pass it to the vertex shader.
            // Go over to shader.vert to see how we finally apply this to the vertices
            shader.SetMatrix4("transform", transform);
            shader.SetMatrix4("view", View.view);
            shader.SetMatrix4("perspecive", View.getPerspective());
            shader.SetVector3("lightPosition", light.Position);
            shader.SetVector3("lightColor",light.Color);
            

            GL.DrawArrays(PrimitiveType.Triangles, 0, _vertices.Length/8);
        }


        private void loadObiektFromObjFile(string path)
        {
            List<Vector3> ver = new List<Vector3>();
            List<Vector2> tex = new List<Vector2>();
            List<Vector3> norm = new List<Vector3>();
            List<Tuple<Tuple<int, int, int>, Tuple<int, int, int>, Tuple<int, int, int>>> faces = new List<Tuple<Tuple<int, int, int>, Tuple<int, int, int>, Tuple<int, int, int>>>();
            try
            {
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
                {
                    while (reader.Peek() >= 0)
                    {
                        string line = reader.ReadLine();
                        if (line.StartsWith("v "))
                        {
                            
                            var vt =line.Split(' ').Skip(1).ToList().Select(s => float.Parse(s, new CultureInfo("en-US"))).ToList();
                            ver.Add(new Vector3(vt[0], vt[1], vt[2]));
                        }
                        if (line.StartsWith("vt "))
                        {
                            var tt = line.Split(' ').Skip(1).ToList().Select(s => float.Parse(s, new CultureInfo("en-US"))).ToList();
                            tex.Add(new Vector2(tt[0], tt[1]));
                        }
                        if (line.StartsWith("vn "))
                        {
                            var vn = line.Split(' ').Skip(1).ToList().Select(s => float.Parse(s, new CultureInfo("en-US"))).ToList();
                            norm.Add(new Vector3(vn[0], vn[1],vn[2]));
                        }
                        if (line.StartsWith("f "))
                        {
                            //indi = line.Split(' ').Skip(1).SelectMany(s => s.Split('/')).Select(c => uint.Parse(c)).ToList();
                            var f = line.Split(' ').Skip(1).Select(s=> { string[] a = s.Split('/');return new Tuple<int, int, int>(int.Parse(a[0]), int.Parse(a[1]), int.Parse(a[2])); }).ToArray();
                            faces.Add(new Tuple<Tuple<int, int, int>, Tuple<int, int, int>, Tuple<int, int, int>>(f[0], f[1], f[2]));
                        }
                    }
                }
                List<float> temp = new List<float>();
                List<uint> indi = new List<uint>();
                uint i = 0;
                foreach(var t in faces)
                {
                    temp.AddRange(new float[] { ver[t.Item1.Item1-1].X , ver[t.Item1.Item1-1].Y , ver[t.Item1.Item1-1].Z });
                    temp.AddRange(new float[] { tex[t.Item1.Item2-1].X, tex[t.Item1.Item2-1].Y});
                    temp.AddRange(new float[] { norm[t.Item1.Item3 - 1].X, norm[t.Item1.Item3 - 1].Y, norm[t.Item1.Item3 - 1].Z });
                    indi.Add(i);
                    i++;
                    temp.AddRange(new float[] { ver[t.Item2.Item1 - 1].X, ver[t.Item2.Item1 - 1].Y, ver[t.Item2.Item1 - 1].Z });
                    temp.AddRange(new float[] { tex[t.Item2.Item2 - 1].X, tex[t.Item2.Item2 - 1].Y });
                    temp.AddRange(new float[] { norm[t.Item2.Item3 - 1].X, norm[t.Item2.Item3 - 1].Y, norm[t.Item2.Item3 - 1].Z });
                    indi.Add(i);
                    i++;
                    temp.AddRange(new float[] { ver[t.Item3.Item1 - 1].X, ver[t.Item3.Item1 - 1].Y, ver[t.Item3.Item1 - 1].Z });
                    temp.AddRange(new float[] { tex[t.Item3.Item2 - 1].X, tex[t.Item3.Item2 - 1].Y });
                    temp.AddRange(new float[] { norm[t.Item3.Item3 - 1].X, norm[t.Item3.Item3 - 1].Y, norm[t.Item3.Item3 - 1].Z });
                    indi.Add(i);
                    i++;
                }
                _vertices = temp.ToArray();
                _indices= indi.ToArray();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found: {0}", path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

    }
}
