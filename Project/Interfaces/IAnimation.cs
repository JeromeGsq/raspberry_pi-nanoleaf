using nano.Project.Models;
using rpi_ws281x;
using System;
using System.Collections.Generic;
using System.Text;

namespace nano.Project.Interfaces
{
    public interface IAnimation
    {
        public void Init(WS281x rpi, int ledCount);
        public void Start();
        public bool Update();
        public void End();
        public void Apply();
    }
}
