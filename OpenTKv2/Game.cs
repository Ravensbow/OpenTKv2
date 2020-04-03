using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTKv2.Common;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;

namespace OpenTK
{
    class Game : GameWindow
    {
        private Shader _shader;
        private Obiekt squer = new Obiekt();
        private Dictionary<Key,double> keyTimers=new Dictionary<Key, double>();

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            GL.Enable(EnableCap.DepthTest);

            _shader = new Shader("Common/shader.vert", "Common/shader.frag");
            _shader.Use();
            //Code:

            squer.Load(_shader);

            //----
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            //Code:

            squer.Render(_shader);

            //----
            SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }
            if ((input.IsKeyDown(Key.P)&&!keyTimers.ContainsKey(Key.P))||(input.IsKeyDown(Key.P)&&keyTimers[Key.P]>0.2))
            {
                if (keyTimers.ContainsKey(Key.P))
                    keyTimers[Key.P] = 0;
                else
                    keyTimers.Add(Key.P, 0);
                OpenTKv2.Common.View.togglePerspective();
            }
            if (keyTimers.ContainsKey(Key.P))
                keyTimers[Key.P] += e.Time;
            base.OnUpdateFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            squer.Unload();
            
            GL.DeleteProgram(_shader.Handle);

            base.OnUnload(e);
        }
    }
}
