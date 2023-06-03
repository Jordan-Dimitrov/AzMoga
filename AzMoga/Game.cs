using System;
using System.Collections.Generic;
using System.Text;

namespace AzMoga
{
    class Game
    {
        public void Start(int width, int height)
        {
            RandomField field = new RandomField(width, height);
            field.GenerateAndRenderField();
        }
        public void Movement()
        {

        }
    }
}
